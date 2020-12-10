using System;
using System.Collections.Generic;
using System.Linq;
namespace Sales.Repositories
{

    using Entities;
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> SAll = new List<Product>();

        void IProductRepository.Add(Product product)
        {
            SAll.Add(product);
        }

        Product IProductRepository.GetById(Guid id)
        {
            return SAll.First(p => p.Id == id);
        }
    }
}

