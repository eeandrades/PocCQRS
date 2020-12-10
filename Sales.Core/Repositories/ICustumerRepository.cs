using Sales.Entities;
using System;

namespace Sales.Repositories
{

    public interface ICustumerRepository
    {
        Customer GetById(Guid id);

        public void Add(Customer customer);
    }
}
