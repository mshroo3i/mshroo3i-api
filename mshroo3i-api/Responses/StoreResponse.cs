namespace mshroo3i_api.Dtos;

public class StoreResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Shortcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string LogoImg { get; set; } = string.Empty;
    public string HeroImg { get; set; } = string.Empty;
    public string InstagramHandle { get; set; } = string.Empty;
    public IList<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    public int Owner { get; set; }
    public string Currency { get; set; } = "KWD";
}