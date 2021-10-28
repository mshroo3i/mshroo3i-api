// See https://aka.ms/new-console-template for more information
using Mshroo3i.Domain;

Console.WriteLine("Hello, World!");

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
        }
    }
};


var zatarSamar = new Store {
    Name = "زعتر سمر",
    Shortcode = "zatar-samar",
    Description = "مشروع كويتي - زعتر أصلي درجة أولى - دُقة (زعتر أحمر) أجود أنواع الزعتر الفلسطيني",
    HeroImg = "header-zatar.jpeg",
    LogoImg = "leaf-logo.png",
    InstagramHandle = "zatarsamar",
    Owner = 1231231, 
    Currency = "KWD"
};
zatarSamar.Name = "زعتر سمر";
zatarSamar.Shortcode = "zatar-samar";
