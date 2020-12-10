using MediatR;

namespace Sales.Commands.OrdersCancel
{
    public interface IOrderCancelCommandHandler : IRequestHandler<OrderCancelCommand, OrderCancelResult>
    {
    }
}
