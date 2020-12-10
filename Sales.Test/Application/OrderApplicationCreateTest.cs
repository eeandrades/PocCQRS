using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Application;
using Sales.Application.Models;
using System;
using System.Linq;

namespace Sales.Test.Applications
{
    [TestClass]
    public class OrderApplicationCreateTest : TestBase
    {

        [TestMethod]
        public void CreateOrder_Success()
        {
            var application = this.ServiceProvider.GetService<IOrderApplication>();

            var order = new OrderModel()
            {
                CustumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Details = new OrderDetailModel[]
                {
                    new()
                    {
                        ProductId = Guid.Parse("0353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                        Quantity = 10
                    },
                }
            };
            var result = application.Create(order).Result;
            Assert.IsTrue(result.IsValid);
        }


        [TestMethod]
        public void CreateOrder_ErrorDuplicatedOrder()
        {
            var application = this.ServiceProvider.GetService<IOrderApplication>();

            var order = new OrderModel()
            {
                CustumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Date = DateTime.Now,
                Details = new OrderDetailModel[]
                {
                    new()
                    {
                        ProductId = Guid.Parse("0353853f-6b34-4b2c-9c98-e51e61ec45d4"),
                        Quantity = 10
                    },
                }
            };

            var result = application.Create(order).Result;
            Assert.IsTrue(result.IsValid);

            //neste ponto o método DoValidate do OrderCreateCommandHandler deverá retornar um erro
            result = application.Create(order).Result;
            Assert.IsFalse(result.IsValid);
            Console.WriteLine(string.Join(Environment.NewLine, result.Errors.Select(e => e.ErrorMessage)));
        }

        [TestMethod]
        public void CreateOrder_ErrorDetail()
        {
            var application = this.ServiceProvider.GetService<IOrderApplication>();

            var order = new OrderModel()
            {
                CustumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e"),
                Details = new OrderDetailModel[0]
            };
            var result = application.Create(order).Result;
            Assert.IsFalse(result.IsValid);
            Console.WriteLine(string.Join(Environment.NewLine, result.Errors.Select(e => e.ErrorMessage)));
        }
    }
}