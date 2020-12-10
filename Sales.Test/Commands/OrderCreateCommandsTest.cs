using Aeon.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Commands.OrdersCreate;
using System;
using System.Linq;


namespace Sales.Test.Commands
{

    [TestClass]
    public class OrderCommandlicationTest : TestBase
    {
        [TestMethod]
        public void CreateOrder_Success()
        {
            var service = this.ServiceProvider.GetService<IRequestHandler<OrderCreateCommand, CommandResponse>>();

            var command = new OrderCreateCommand()
            {
                CustumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Details = new OrderDetailCommand[]
                {
                    new()
                    {
                        ProductId = Guid.Parse("0353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                        Quantity = 10
                    },
                }
            };
            var result = service.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void CreateOrder_ErrorDuplicatedOrder()
        {
            var service = this.ServiceProvider.GetService<IRequestHandler<OrderCreateCommand, CommandResponse>>();


            var command = new OrderCreateCommand()
            {
                CustumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Date = DateTime.Now,
                Details = new OrderDetailCommand[]
                {
                    new()
                    {
                        ProductId = Guid.Parse("0353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                        Quantity = 10
                    },
                }
            };
            var result = service.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.IsTrue(result.IsValid);

            //neste ponto o método DoValidate do OrderCreateCommandHandler deverá retornar um erro
            result = service.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.IsFalse(result.IsValid);
            Console.WriteLine(string.Join(Environment.NewLine, result.Errors.Select(e => e.ErrorMessage)));
        }

        [TestMethod]
        public void CreateOrder_ErrorDetail()
        {
            var service = this.ServiceProvider.GetService<IRequestHandler<OrderCreateCommand, CommandResponse>>();

            var command = new OrderCreateCommand()
            {
                CustumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Details = new OrderDetailCommand[0]
            };
            var result = service.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.IsFalse(result.IsValid);
            Console.WriteLine(string.Join(Environment.NewLine, result.Errors.Select(e => e.ErrorMessage)));
        }
    }
}