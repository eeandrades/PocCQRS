using Aeon;
using Aeon.Domain;
using Sales.Application.Models;
using Sales.Commands.OrdersCancel;
using Sales.Commands.OrdersCreate;
using Sales.Entities;
using Sales.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly ICommandMediator _mediatorHandler;
        private readonly IOrderQuery _orderQuery;

        public OrderApplication(ICommandMediator mediatorHandler, IOrderQuery orderQuery)
        {
            this._mediatorHandler = mediatorHandler ?? throw new ArgumentNullException(nameof(mediatorHandler));
            this._orderQuery = orderQuery ?? throw new ArgumentNullException(nameof(orderQuery));
        }

        #region util

        private static OrderModel CreateOrderModel(Order orderEntity)
        {
            return new OrderModel()
            {
                CustumerId = orderEntity.Customer.Id,
                Date = orderEntity.CreatedDateTime,
                OrderId = orderEntity.Id,
                Details = orderEntity.Details.Select(d => new OrderDetailModel()
                {
                    ProductId = d.Product.Id,
                    Quantity = d.Quantity
                })
            };
        }

        private static OrderViewModel CreateOrderViewModel(Order orderEntity)
        {
            return new OrderViewModel()
            {
                OrderId = orderEntity.Id,
                OrderDate = orderEntity.CreatedDateTime,
                CustumerName = orderEntity.Customer.Name
            };
        }

        #endregion


        async Task<OrderCancelResult> IOrderApplication.Cancel(Guid orderId)
        {
            var command = new OrderCancelCommand()
            {
                OrderId = orderId
            };

            return await this._mediatorHandler.SendCommand(command);
        }

        async Task<CommandResponse> IOrderApplication.Create(OrderModel order)
        {
            //existe um cara que chama mapper,utilizado para mapear de uma classe para outra, não utilizei aqui para não complicar, mas aconselho usar nos projetos
            var orderCommand = new OrderCreateCommand()
            {
                OrderId = order.OrderId,
                CustumerId = order.CustumerId,
                Date = order.Date,
                Details = order.Details.Select(d => new Sales.Commands.OrdersCreate.OrderDetailCommand()
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity
                })
            };

            return await this._mediatorHandler.SendCommand(orderCommand);
        }

        async Task<IEnumerable<OrderModel>> IOrderApplication.FindByCustumer(Guid custumerId)
        {
            return await this._orderQuery
                .FindAll()
                .Where(o => o.Customer.Id == custumerId)
                .Select(o => CreateOrderModel(o))
                .ToTask();
        }

        async Task<IEnumerable<OrderViewModel>> IOrderApplication.FindViewByCustumer(Guid custumerId)
        {
            return await this._orderQuery
                .FindAll()
                .Where(o => o.Customer.Id == custumerId)
                .Select(o => CreateOrderViewModel(o))
                .ToTask();
        }
    }
}
