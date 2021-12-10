using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using mshroo3i_api.Dtos;
using mshroo3i_api.Requests;

namespace mshroo3i_api.Controllers;

[Route("stores")]
public class StoresController : MainController
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public StoresController(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    [HttpGet("{shortcode}",Name = "GetStore")]
    public async Task<IActionResult> GetStore(string shortcode)
    {
        var store = await _applicationContext.Stores
            .Include(s => s.Products)
            .ThenInclude(p => p.ProductOptions)
            .ThenInclude(po => po.Options)
            .FirstOrDefaultAsync(s => s.Shortcode == shortcode);
 
        if (store == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StoreResponse>(store));
    }

    [HttpPut("{shortcode}/product/{productId}", Name = "UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(string shortcode, int productId, ProductRequest product)
    {
        var productToUpdate = await _applicationContext.Products.FirstOrDefaultAsync(p => p.Store.Shortcode == shortcode && p.Id == productId);
        if (productToUpdate is null)
        {
            return NotFound();
        }

        _mapper.Map(product, productToUpdate);
        await _applicationContext.SaveChangesAsync();

        return Ok();
    }
}