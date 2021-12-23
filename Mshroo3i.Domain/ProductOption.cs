namespace Mshroo3i.Domain
{
    public class ProductOption : Entity
    {
        public ProductOption()
        {
        }

        public ProductOption(DateTime created) : base(created)
        {
        }

        public string OptionName { get; set; }
        public IList<ProductFieldOption> Options { get; set; } = new List<ProductFieldOption>();
        public OptionType OptionType { get; set; }
    }
}