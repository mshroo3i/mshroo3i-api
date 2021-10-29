namespace Mshroo3i.Domain
{
    public class Product: Entity
    {
        public Product(DateTime created) : base(created)
        {
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public IList<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
    }
}