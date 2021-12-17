namespace mshroo3i_api.Dtos;

// shortcode: 'zatar-samar',
// storeNameEn: 'Zatar Samar',
// storeNameAr: 'زعتر سمر',
// storeDescriptionAr: 'مشروع كويتي - زعتر أصلي درجة أولى - دُقة (زعتر أحمر) أجود أنواع الزعتر الفلسطيني',
// heroImage: ZatarSamarHero,
// instagramLink: 'https://www.instagram.com/zatarsamar/',
// whatsappLink: 'https://wa.me/96565544219'

public class StoreResponse
{
    public int Id { get; set; }
    public string NameEn { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Shortcode { get; set; } = string.Empty;
    public string HeroImg { get; set; } = string.Empty;
    public string InstagramHandle { get; set; } = string.Empty;
    public string WhatsAppUri { get; set; } = string.Empty;
    public string LogoImg { get; set; } = string.Empty;
    public IList<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    public int Owner { get; set; }
    public string Currency { get; set; } = "KWD";
}