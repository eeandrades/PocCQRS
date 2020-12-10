using Aeon.Domain;
using Microsoft.Extensions.DependencyInjection;
using Sales.Repositories;
using System;

namespace Sales.Test
{

    public class TestBase
    {
        protected ServiceProvider ServiceProvider { get; init; }
        public TestBase()
        {
            OrderRepository.Clear();

            var services = new ServiceCollection();
            this.ServiceProvider = Sales.Infra.DependencyInjection.NativeInjectorBootStrapper.RegisterServices(services);
            this.CreateCustumers();
            this.CreateProducts();
        }

        private void CreateProducts()
        {

            var repository = this.ServiceProvider.GetService<IProductRepository>();

            repository.Add(new()
            {
                Id = Guid.Parse("0353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                Name = "Cervjea",
                Price = new Money(10)
            });
            repository.Add(new()
            {
                Id = Guid.Parse("1353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                Name = "Picanha",
                Price = new Money(79)
            });
            repository.Add(new()
            {
                Id = Guid.Parse("2353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                Name = "Carvão",
                Price = new Money(9)
            });
            repository.Add(new()
            {
                Id = Guid.Parse("3353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                Name = "Linguiça",
                Price = new Money(12)
            });
        }

        private void CreateCustumers()
        {
            var repository = this.ServiceProvider.GetService<ICustumerRepository>();
            repository.Add(new()
            {
                Id = Guid.Parse("0f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Name = "Emerson"
            });
            repository.Add(new()
            {
                Id = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Name = "Raul"
            });
            repository.Add(new()
            {
                Id = Guid.Parse("2f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Name = "Pedro"
            });
        }

    }
}
