namespace Mshroo3i.Domain
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public IList<ProductOption> ProductOptions { get; set; }
    }
}