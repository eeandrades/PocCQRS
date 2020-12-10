using Aeon.Domain;
using System;

namespace Sales.Entities
{
    public class Product : Entity<Guid>
    {
        public string Name { get; set; }

        public Money Price { get; set; }
    }
}
