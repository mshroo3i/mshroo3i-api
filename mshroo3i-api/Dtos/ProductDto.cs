namespace mshroo3i_api.Dtos;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public double Price { get; set; } = 0;
    public IList<ProductOptionDto> ProductOptions { get; set; } = new List<ProductOptionDto>();
}