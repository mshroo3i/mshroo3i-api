namespace Mshroo3i.Domain
{
    public class Option : Entity
    {
        public Option()
        {
        }

        public Option(DateTime created) : base(created)
        {
        }

        public string Name { get; set; } = string.Empty;
        public double PriceIncrement { get; set; } = 0;
    }
}