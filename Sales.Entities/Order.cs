using Aeon.Domain;
using System;
using System.Collections.Generic;

namespace Sales.Entities
{
    public class Order : Entity<Guid>
    {
        public Customer Customer { get; init; }

        public OrderStatus Status { get; set; } = new OrderStatus(OrderStatusCodes.Pending);

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        private readonly List<OrderDetail> _details = new List<OrderDetail>();
        public IEnumerable<OrderDetail> Details
        {
            get => this._details;
            init
            {
                this._details = new List<OrderDetail>();
                this._details.AddRange(value);
            }
        }
        public Order AddDetail(OrderDetail detail)
        {
            this._details.Add(detail);
            return this;
        }
    }
}
