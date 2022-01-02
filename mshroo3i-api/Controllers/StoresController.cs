using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using Mshroo3i.Domain;
using mshroo3i_api.Dtos;
using mshroo3i_api.Requests;

namespace mshroo3i_api.Controllers;

[ApiController]
[Route("api/stores")]
public class StoresController : ControllerBase
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public StoresController(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    [HttpGet(Name = "GetStores")]
    public async Task<IActionResult> GetStores()
    {
        var stores = await _applicationContext.Stores.Take(5).ToListAsync();
        if (stores.Count == 0)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IList<StoreResponse>>(stores));
    }

    [HttpGet("{shortcode}", Name = "GetStore")]
    public async Task<IActionResult> GetStore(string shortcode)
    {
        var store = await _applicationContext.Stores
            .Include(s => s.Products)
            .ThenInclude(p => p.ProductFields)
            .ThenInclude(po => po.Options)
            .ProjectTo<StoreResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(s => s.Shortcode == shortcode);

        if (store == null)
        {
            return NotFound();
        }

        return Ok(store);
    }

    [HttpPost(Name = "AddStore")]
    public async Task<IActionResult> AddStore(StoreAddRequest newStoreAdd)
    {
        var store = _mapper.Map<Store>(newStoreAdd);
        var shortcodeTaken = await _applicationContext.Stores.AnyAsync(
            s => EF.Functions.Collate(s.Shortcode, "SQL_Latin1_General_CP1_CI_AS") == newStoreAdd.Shortcode);

        if (shortcodeTaken)
        {
            ModelState.AddModelError(nameof(newStoreAdd.Shortcode),
                $"shortcode {newStoreAdd.Shortcode} is already taken");
            return BadRequest(ModelState);
        }

        var res = await _applicationContext.Stores.AddAsync(store);
        await _applicationContext.SaveChangesAsync();

        return CreatedAtAction("GetStore", new {shortcode = res.Entity.Shortcode},
            _mapper.Map<StoreResponse>(res.Entity));
    }
}