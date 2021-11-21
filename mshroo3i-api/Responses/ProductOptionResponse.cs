using Mshroo3i.Domain;

namespace mshroo3i_api.Dtos;

public class ProductOptionResponse
{
    public int Id { get; set; }
    public string OptionName { get; set; } = string.Empty;
    public IList<OptionResponse> Options { get; set; } = new List<OptionResponse>();
    public OptionType OptionType { get; set; }
}