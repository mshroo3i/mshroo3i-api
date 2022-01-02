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
[Route("api/stores/{shortcode}/products")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public ProductsController(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    [HttpGet("{productId}", Name = "GetProduct")]
    public async Task<IActionResult> GetProduct(string shortcode, int productId)
    {
        var product = await _applicationContext.Products
            .Include(p => p.ProductFields)
            .ThenInclude(pf => pf.Options)
            .Where(p => p.Store.Shortcode == shortcode && p.Id == productId)
            .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
        
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPut("{productId}", Name = "UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(string shortcode, int productId, ProductUpdateRequest productUpdate)
    {
        var productToUpdate = await _applicationContext.Products.FirstOrDefaultAsync(p => p.Store.Shortcode == shortcode && p.Id == productId);
        if (productToUpdate is null)
        {
            return NotFound();
        }

        _mapper.Map(productUpdate, productToUpdate);
        await _applicationContext.SaveChangesAsync();

        return Ok();
    }
    
    [HttpPost( Name = "AddProduct")]
    public async Task<IActionResult> AddProduct(string shortcode, ProductAddRequest newProduct)
    {
        var store = await _applicationContext.Stores.FirstOrDefaultAsync(s => s.Shortcode == shortcode);
        if (store is null)
        {
            return NotFound();
        }

        var product = _mapper.Map<Product>(newProduct);
        store.Products.Add(product);
        
        await _applicationContext.SaveChangesAsync();

        return CreatedAtAction(
            "GetProduct", 
            new {shortcode, productId = product.Id}, 
            _mapper.Map<ProductResponse>(product));
    }
}