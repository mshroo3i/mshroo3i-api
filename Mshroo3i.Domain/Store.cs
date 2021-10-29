namespace Mshroo3i.Domain
{
    public class Store: Entity
    {
        public Store(DateTime created, int owner) : base(created)
        {
            Owner = owner;
        }

        public string Name { get; set; } = string.Empty;
        public string Shortcode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LogoImg { get; set; } = string.Empty;
        public string HeroImg { get; set; } = string.Empty;
        public string InstagramHandle { get; set; } = string.Empty;
        public IList<Product> Products { get; set; } = new List<Product>();
        public int Owner { get; set; }
        public string Currency { get; set; } = "KWD";
    }
}