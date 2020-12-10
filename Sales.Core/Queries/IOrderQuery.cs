using Sales.Entities;
using System;
using System.Collections.Generic;

namespace Sales.Queries
{
    public interface IOrderQuery
    {
        public IEnumerable<Order> FindAll();
    }
}
