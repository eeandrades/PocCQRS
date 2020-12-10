using Aeon.Domain;
using System;

namespace Sales.Commands.OrdersCancel
{
    public class OrderCancelResult: CommandResponse
    {
        public Guid CancelationId { get; set; }

        public DateTime CancelationDate { get; set; }
    }
}
