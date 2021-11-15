// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
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
        Image = "zatar-2.jpeg",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<Option>
                  {
                      new Option
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new Option
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
        Image = "zatar-2.jpeg",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<Option>
                  {
                      new Option
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new Option
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
        Image = "do2a-2.jpeg",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<Option>
                  {
                      new Option
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new Option
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
        Image = ""
    },
    new Product
    {
        Name = "زيت تركي درجه اولى",
        Description = "متوفر باللتر",
        Price = 3,
        Image = ""
    },
    new Product
    {
        Name = "زيتون بالخلطه",
        Description = "نص كيلو",
        Price = 2,
        Image = "zaytoon-mix-1.jpeg"
    },
    new Product
    {
        Name = "مقدوس حبه صغيره قرشة اقل من نص",
        Description = "",
        Price = 2.5,
        Image = "magdoos-1.jpeg"
    },
    new Product
    {
        Name = "سماق اردني درجه اولى",
        Description = "متوفر ربع كيلو أو نص كيلو",
        Price = 1.25,
        Image = "",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<Option>
                  {
                      new Option
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new Option
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
        Image = "",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<Option>
                  {
                      new Option
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new Option
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
        Image = "",
        ProductOptions = new List<ProductOption>
        {
            new ProductOption
            {
                 OptionName = "الحجم",
                 OptionType = OptionType.SingleSelect,
                  Options = new List<Option>
                  {
                      new Option
                      {
                           Name = "علبه ريع كيلو",
                           PriceIncrement = 0,
                      },
                      new Option
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
    Name = "زعتر سمر",
    Shortcode = "zatar-samar",
    Description = "مشروع كويتي - زعتر أصلي درجة أولى - دُقة (زعتر أحمر) أجود أنواع الزعتر الفلسطيني",
    HeroImg = "header-zatar.jpeg",
    LogoImg = "leaf-logo.png",
    InstagramHandle = "zatarsamar",
    Owner = 1231231,
    Currency = "KWD"
};


foreach (var product in products)
{
    zatarSamar.Products.Add(product);
}

SqlAuthenticationProvider.SetProvider(
    SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow, 
    new CustomAzureSqlAuthProvider());
var sqlConnection = new SqlConnection(ApplicationContext.ConnectionString);
var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
optionsBuilder.UseSqlServer(sqlConnection, options =>
{
    options.EnableRetryOnFailure();
});
var context = new ApplicationContext(optionsBuilder.Options);

context.Stores.Add(zatarSamar);

context.SaveChanges();