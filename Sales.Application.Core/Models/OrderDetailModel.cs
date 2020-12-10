using System;

namespace Sales.Application.Models
{
    public class OrderDetailModel
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
