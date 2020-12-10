using System;
using System.Collections.Generic;


namespace Sales.Application.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; init; } = Guid.NewGuid();
        public Guid CustumerId { get; init; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderDetailModel> Details { get; init; } = new OrderDetailModel[0];
    }
}
