namespace Mshroo3i.Domain
{
    public class ProductFieldOption : Entity
    {
        public ProductFieldOption()
        {
        }

        public ProductFieldOption(DateTime created) : base(created)
        {
        }

        public string Name { get; set; }
        public double PriceIncrement { get; set; }
    }
}