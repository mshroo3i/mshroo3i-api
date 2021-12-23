namespace mshroo3i_api.Requests;

public class ProductUpdateRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public string? ImageSrc { get; set; }
}