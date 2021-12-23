// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using Mshroo3i.Domain;

var products = new List<Product>
{
    new Product
    {
        Name = "زعتر فاخر فلسطيني",
        Description = "متوفر علبه ريع كيلو أو علبه نص كيلو",
        Price = 2,
        ImageSrc = "zatar-2.jpeg",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<ProductFieldOption>
                  {
                      new ProductFieldOption
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new ProductFieldOption
                      {
                           Name = "علبه نص كيلو",
                           PriceIncrement = 2,
                      },
                  }
            }
        },
    },
    new Product
    {
        Name = "زعتر ممتاز فلسطيني",
        Description = "متوفر علبه ريع كيلو أو علبه نص كيلو",
        Price = 1.5,
        ImageSrc = "zatar-2.jpeg",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<ProductFieldOption>
                  {
                      new ProductFieldOption
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new ProductFieldOption
                      {
                           Name = "علبه نص كيلو",
                           PriceIncrement = 1.5,
                      },
                  }
            }
        },
    },
    new Product
    {
        Name = "دقه فلسطينيه زعتر احمر",
        Description = "متوفر علبه ريع كيلو أو علبه نص كيلو",
        Price = 1.5,
        ImageSrc = "do2a-2.jpeg",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<ProductFieldOption>
                  {
                      new ProductFieldOption
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new ProductFieldOption
                      {
                           Name = "علبه نص كيلو",
                           PriceIncrement = 1.5,
                      },
                  }
            }
        },
    },
    new Product
    {
        Name = "زيت زيتون فلسطيني عصره اولى",
        Description = "متوفر باللتر",
        Price = 6,
        ImageSrc = ""
    },
    new Product
    {
        Name = "زيت تركي درجه اولى",
        Description = "متوفر باللتر",
        Price = 3,
        ImageSrc = ""
    },
    new Product
    {
        Name = "زيتون بالخلطه",
        Description = "نص كيلو",
        Price = 2,
        ImageSrc = "zaytoon-mix-1.jpeg"
    },
    new Product
    {
        Name = "مقدوس حبه صغيره قرشة اقل من نص",
        Description = "",
        Price = 2.5,
        ImageSrc = "magdoos-1.jpeg"
    },
    new Product
    {
        Name = "سماق اردني درجه اولى",
        Description = "متوفر ربع كيلو أو نص كيلو",
        Price = 1.25,
        ImageSrc = "",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<ProductFieldOption>
                  {
                      new ProductFieldOption
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new ProductFieldOption
                      {
                           Name = "علبه نص كيلو",
                           PriceIncrement = 1.25,
                      },
                  }
            }
        },
    },
    new Product
    {
        Name = "سمسميه اردنيه مغلفه",
        Description = "متوفر ربع كيلو أو نص كيلو",
        Price = 1.5,
        ImageSrc = "",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<ProductFieldOption>
                  {
                      new ProductFieldOption
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new ProductFieldOption
                      {
                           Name = "علبه نص كيلو",
                           PriceIncrement = 3,
                      },
                  }
            }
        },
    },
    new Product
    {
        Name = "مرميه",
        Description = "متوفر ربع كيلو أو نص كيلو",
        Price = 1.25,
        ImageSrc = "",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<ProductFieldOption>
                  {
                      new ProductFieldOption
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new ProductFieldOption
                      {
                           Name = "علبه نص كيلو",
                           PriceIncrement = 2.5,
                      },
                  }
            }
        },
    },
};

var zatarSamar = new Store
{
    NameAr = "زعتر سمر",
    NameEn = "Zatar Samar",
    Shortcode = "zatar-samar",
    Description = "مشروع كويتي - زعتر أصلي درجة أولى - دُقة (زعتر أحمر) أجود أنواع الزعتر الفلسطيني",
    HeroImg = "header-zatar.jpeg",
    LogoImg = "leaf-logo.png",
    InstagramHandle = "zatarsamar",
    WhatsAppUri = "https://wa.me/96565544219",
    Owner = 1231231,
    Currency = "KWD"
};


foreach (var product in products)
{
    zatarSamar.Products.Add(product);
}

var sqlConnection = ConnectionFactory.CreateSqlConnection(ApplicationContext.ConnectionString);
var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
optionsBuilder.UseSqlServer(sqlConnection, options =>
{
    options.EnableRetryOnFailure();
});
var context = new ApplicationContext(optionsBuilder.Options);

context.Stores.Add(zatarSamar);

context.SaveChanges();