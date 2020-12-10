using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Repositories
{
    public class CustumerRepository : ICustumerRepository
    {
        private static readonly List<Customer> SAll = new List<Customer>();
   

        void ICustumerRepository.Add(Customer customer)
        {
            SAll.Add(customer);
        }

        Customer ICustumerRepository.GetById(Guid id)
        {
            return SAll.First(p => p.Id == id);
        }
    }
}
