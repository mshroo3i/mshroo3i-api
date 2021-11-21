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
        public IList<Option> Options { get; set; } = new List<Option>();
        public OptionType OptionType { get; set; }
    }
}