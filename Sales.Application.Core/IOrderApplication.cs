using System.Threading.Tasks;
using Aeon.Domain;
using Sales.Application.Models;
using Sales.Commands.OrdersCancel;
using System;
using System.Collections.Generic;

namespace Sales.Application
{
    public interface IOrderApplication
    {
        Task<CommandResponse> Create(OrderModel order);

        Task<OrderCancelResult> Cancel(Guid orderId);

        Task<IEnumerable<OrderModel>> FindByCustumer(Guid custumerId);

        Task<IEnumerable<OrderViewModel>> FindViewByCustumer(Guid custumerId);
    }
}
