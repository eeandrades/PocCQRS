using Sales.Entities;
using System;
using System.Collections.Generic;

namespace Sales.Repositories
{
    public interface IOrderRepository
    {
        public void Save(Order order);

        public bool Exists(Guid custumerId, DateTime createdDate);

        public Order FindByUid(Guid id);
    }
}
