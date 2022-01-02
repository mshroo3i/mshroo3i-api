using System.Linq;
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
[Route("api/stores/{shortcode}/products/{productId}/productFields")]
public class ProductFieldsController: ControllerBase
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public ProductFieldsController(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    [HttpGet("{productFieldId}", Name = "GetProductField")]
    public async Task<IActionResult> GetProductField(string shortcode, int productId, int productFieldId)
    {
        var productField = await _applicationContext.ProductFields
            .Include(pf => pf.Options)
            .Where(pf => pf.Product.Id == productId && pf.Id == productFieldId && pf.Product.Store.Shortcode == shortcode)
            .ProjectTo<ProductFieldResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
        
        if (productField is null)
        {
            return NotFound();
        }

        return Ok(productField);
    }
    
    [HttpPost( Name = "AddProductField")]
    [Produces(typeof(ProductFieldAddRequest))]
    public async Task<IActionResult> AddProductField(string shortcode, int productId, ProductFieldAddRequest newProductField)
    {
        var product = await _applicationContext.Products
            .Where(p => p.Store.Shortcode == shortcode && p.Id == productId)
            .FirstOrDefaultAsync();

        if (product is null) return NotFound();

        var productField = _mapper.Map<ProductField>(newProductField);
        product.ProductFields.Add(productField);

        await _applicationContext.SaveChangesAsync();

        return CreatedAtAction(
            "GetProductField", 
            new {shortcode, productId = product.Id, productFieldId = productField.Id}, 
            _mapper.Map<ProductFieldResponse>(productField));
    }
}