using System;

namespace Sales.Application.Models
{
    public class OrderViewModel
    {
        public Guid OrderId { get; init; }

        public string CustumerName { get; init; }

        public DateTime OrderDate { get; init; }
    }
}
