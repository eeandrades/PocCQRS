using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sales.Application;
using Sales.Application.Models;
using System;
using System.Linq;

namespace Sales.Test.Applications
{
    [TestClass]
    public class OrderApplicationCancelTest : TestBase
    {

        [TestMethod]
        public void CancelOrder_Success()
        {
            var application = this.ServiceProvider.GetService<IOrderApplication>();

            var order = new OrderModel()
            {
                OrderId = Guid.NewGuid(),
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
            
            //cria o pedido
            var result = application.Create(order).Result;
            Assert.IsTrue(result.IsValid);

            //cancela o pedido
            var cancelResult = application.Cancel(order.OrderId).Result;

            Assert.IsTrue(cancelResult.IsValid);
            Console.WriteLine($"CancelationId: {cancelResult.CancelationId}, Cancelation Date: {cancelResult.CancelationDate}");
        }


        [TestMethod]
        public void CancelOrder_ErrorOrderNotFound()
        {
            var application = this.ServiceProvider.GetService<IOrderApplication>();
            var cancelResult = application.Cancel(Guid.NewGuid()).Result;
            Assert.IsTrue(cancelResult.IsInvalid);

            Console.WriteLine(string.Join(Environment.NewLine, cancelResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
}