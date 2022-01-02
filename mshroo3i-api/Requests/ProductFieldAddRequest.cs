using Mshroo3i.Domain;

namespace mshroo3i_api.Requests;

public class ProductFieldAddRequest
{
    public string OptionName { get; set; } = string.Empty;
    public OptionType OptionType { get; set; }
    public IList<ProductFieldOptionsAddRequest> Options { get; set; }
}