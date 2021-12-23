using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using mshroo3i_api.Dtos;
using mshroo3i_api.Requests;

namespace mshroo3i_api.Controllers;

public class ProductsController : MainController
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public ProductsController(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    [HttpGet("{shortcode}/product/{productId}", Name = "GetProduct")]
    public async Task<IActionResult> GetProduct(string shortcode, int productId)
    {
        var product = await _applicationContext.Products.FirstOrDefaultAsync(p => p.Store.Shortcode == shortcode && p.Id == productId);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductResponse>(product));
    }

    [HttpPut("{shortcode}/product/{productId}", Name = "UpdateProduct")]
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
}