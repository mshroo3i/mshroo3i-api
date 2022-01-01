namespace Mshroo3i.Domain
{
    public class Store: Entity
    {
        public Store()
        {
        }

        public Store(DateTime created, int owner) : base(created)
        {
            Owner = owner;
        }

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Shortcode { get; set; }
        public string Description { get; set; }
        public string? LogoImg { get; set; }
        public string HeroImg { get; set; }
        public string InstagramHandle { get; set; }
        public string WhatsAppUri { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public IList<ProductSection> Sections { get; set; }
        public int Owner { get; set; }
        public string Currency { get; set; } = "KWD";
    }
}