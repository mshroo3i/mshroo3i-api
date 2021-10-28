namespace Mshroo3i.Domain
{
    public class ProductOption
    {
        public string OptionName { get; set; }
        public IList<Option> Options { get; set; }
        public OptionType OptionType { get; set; }
    }
}