namespace mshroo3i_api.Dtos;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageSrc { get; set; } = string.Empty;
    public double Price { get; set; } = 0;
    public IList<ProductFieldResponse> ProductFields { get; set; } = new List<ProductFieldResponse>();
}