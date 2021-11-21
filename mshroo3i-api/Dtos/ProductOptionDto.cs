using Mshroo3i.Domain;

namespace mshroo3i_api.Dtos;

public class ProductOptionDto
{
    public string OptionName { get; set; } = string.Empty;
    public IList<OptionDto> Options { get; set; } = new List<OptionDto>();
    public OptionType OptionType { get; set; }
}