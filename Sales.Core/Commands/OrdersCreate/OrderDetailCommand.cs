using System;

namespace Sales.Commands.OrdersCreate
{
    public class OrderDetailCommand
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }

    }
}
