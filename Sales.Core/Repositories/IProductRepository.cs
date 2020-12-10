using Sales.Entities;
using System;

namespace Sales.Repositories
{
    public interface IProductRepository
    {
        Product GetById(Guid id);

        public void Add(Product product);
    }
}
