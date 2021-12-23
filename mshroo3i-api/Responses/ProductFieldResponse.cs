using Mshroo3i.Domain;

namespace mshroo3i_api.Dtos;

public class ProductFieldResponse
{
    public int Id { get; set; }
    public string OptionName { get; set; } = string.Empty;
    public IList<ProductFieldOptionResponse> Options { get; set; } = new List<ProductFieldOptionResponse>();
    public OptionType OptionType { get; set; }
}