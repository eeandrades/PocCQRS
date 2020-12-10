using Aeon.Domain;
using System;

namespace Sales.Entities
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; init; }
    }
}
