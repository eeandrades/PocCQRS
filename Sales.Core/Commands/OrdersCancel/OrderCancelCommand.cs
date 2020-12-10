using Aeon.Domain;
using System;

namespace Sales.Commands.OrdersCancel
{
    public class OrderCancelCommand : Command<OrderCancelResult>
    {
        public Guid OrderId { get; init; }
    }
}
