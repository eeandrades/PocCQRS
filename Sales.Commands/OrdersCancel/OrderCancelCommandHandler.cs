using Aeon.Domain;
using FluentValidation.Results;
using Sales.Repositories;
using System;

namespace Sales.Commands.OrdersCancel
{
    public class OrderCancelCommandHandler : CommandHandler<OrderCancelCommand, OrderCancelResult>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCancelCommandHandler(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        protected override OrderCancelResult DoExecute(OrderCancelCommand command)
        {
            var order = this._orderRepository.FindByUid(command.OrderId);
            order.Status = new Entities.OrderStatus(Entities.OrderStatusCodes.Canceled);
            this._orderRepository.Save(order);

            return new OrderCancelResult()
            {
                CancelationDate = DateTime.Now,
                CancelationId = Guid.NewGuid()
            };
        }

        protected override ValidationResult DoValidate(OrderCancelCommand command)
        {
            if (this._orderRepository.FindByUid(command.OrderId) == null)
            {
                return new ValidationResult().AddError("Order not found");
            }
            return base.DoValidate(command);
        }
    }
}
