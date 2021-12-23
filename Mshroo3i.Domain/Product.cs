namespace Mshroo3i.Domain
{
    public class Product: Entity
    {
        public Product()
        {
        }

        public Product(DateTime created) : base(created)
        {
        }
        
        public Store Store { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        public double Price { get; set; }
        public IList<ProductField> ProductFields { get; set; } = new List<ProductField>();
    }
}