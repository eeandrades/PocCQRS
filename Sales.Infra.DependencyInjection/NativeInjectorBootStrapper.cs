using Aeon.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application;
using Sales.Commands.OrdersCreate;
using Sales.Queries;
using Sales.Repositories;

namespace Sales.Infra.DependencyInjection
{
    public static class NativeInjectorBootStrapper
    {
        public static ServiceProvider RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(
                 System.Reflection.Assembly.Load("Sales.Commands")
            );
            services.AddScoped<ICommandMediator, InMemoryBus>();            
            //necessário apenas se chamar o command diretamente, veja que no caso do cancel os testes não deram erro pois estou usando apenas os testes de aplicação que por sua vez são utilizados pelo mediator
            services.AddScoped<IRequestHandler<OrderCreateCommand, CommandResponse>, OrderCreateCommandHandler>();
            //repositorios
            services.AddScoped<ICustumerRepository, CustumerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderQuery, OrderRepository>();
            //application
            services.AddScoped<IOrderApplication, OrderApplication>();
            return services.BuildServiceProvider();
        }
    }
}
