using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Application;
using Sales.Application.Models;
using System;
using System.Linq;

namespace Sales.Test.Applications
{
    [TestClass]
    public class OrderApplicationFind : TestBase
    {

        private static void CreateOrder(IOrderApplication application, Guid custumerId)
        {
            var order = new OrderModel()
            {
                CustumerId = custumerId,
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
        }



        [TestMethod]
        public void FindByCustumer_Success()
        {
            var custumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e");
            var custumerId2 = Guid.Parse("2f1aa443-373f-44a6-bbe6-002fcbaffb4e");
            var application = this.ServiceProvider.GetService<IOrderApplication>();

            CreateOrder(application, custumerId);
            CreateOrder(application, custumerId2);
            CreateOrder(application, custumerId);
            CreateOrder(application, custumerId2);
            CreateOrder(application, custumerId);
            CreateOrder(application, custumerId2);
            CreateOrder(application, custumerId);

            var orders = application.FindByCustumer(custumerId).Result;

            Assert.IsTrue(orders.Count() == 4);
        }

        [TestMethod]
        public void FindViewByCustumer_Success()
        {
            var custumerId = Guid.Parse("1f1aa443-373f-44a6-bbe6-002fcbaffb4e");
            var custumerId2 = Guid.Parse("2f1aa443-373f-44a6-bbe6-002fcbaffb4e");
            var application = this.ServiceProvider.GetService<IOrderApplication>();

            CreateOrder(application, custumerId);
            CreateOrder(application, custumerId2);
            CreateOrder(application, custumerId);
            CreateOrder(application, custumerId2);
            CreateOrder(application, custumerId);
            CreateOrder(application, custumerId2);
            CreateOrder(application, custumerId);

            var orders = application.FindViewByCustumer(custumerId).Result;


            Assert.IsTrue(orders.Count() == 4);
        }
    }
}