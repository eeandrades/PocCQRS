using Aeon.Domain;
using System;

namespace Sales.Entities
{
    public class OrderDetail : Entity<Guid>
    {
        public Product Product { get; init; }

        public int Quantity { get; set; }
    }
}
