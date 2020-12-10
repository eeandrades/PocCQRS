using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Queries;

namespace Sales.Repositories
{
    public class OrderRepository : IOrderRepository, IOrderQuery
    {
        private static readonly List<Order> SAll = new List<Order>();
        public static void Clear()
        {
            SAll.Clear();
        }

        bool IOrderRepository.Exists(Guid custumerId, DateTime createdDate)
        {
            return SAll.Any(o => o.Customer.Id == custumerId && o.CreatedDateTime == createdDate);
        }

        public OrderRepository()
        {

        }

        Order IOrderRepository.FindByUid(Guid id)
        {
            return SAll.FirstOrDefault(o => o.Id == id);
        }

        void IOrderRepository.Save(Order order)
        {
            if (SAll.Any(o => o.Id == order.Id))
                SAll.RemoveAll(o => o.Id == order.Id);
            SAll.Add(order);
        }

        IEnumerable<Order> IOrderQuery.FindAll()
        {
            return SAll.ToArray();
        }
    }
}
