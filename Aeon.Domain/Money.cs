namespace Aeon.Domain
{
    public record Money
    {
        public decimal Value { get; init; }

        public Money(decimal value)
        {
            this.Value = value;
        }

        public Money()
        {

        }
    }
}
