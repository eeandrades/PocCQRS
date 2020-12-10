namespace Sales.Entities
{
    public record OrderStatus(OrderStatusCodes Code)
    {
        public string Name => Code.ToString();
    }
}
