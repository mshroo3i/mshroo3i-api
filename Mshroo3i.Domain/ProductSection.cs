namespace Mshroo3i.Domain;

public class ProductSection : Entity
{
    public string Name { get; set; }
    public IList<Product> Products { get; set; }
    public int Position { get; set; }
    public Store Store { get; set; }
}