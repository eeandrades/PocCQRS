using Aeon.Domain;
using FluentValidation.Results;
using Sales.Repositories;
using System;
using System.Linq;

namespace Sales.Commands.OrdersCreate
{
    public class OrderCreateCommandHandler : CommandHandler<OrderCreateCommand, CommandResponse>
    {
        private readonly IOrderRepository _repository;
        private readonly ICustumerRepository _custumerRepository;
        private readonly IProductRepository _productRepository;

        private Entities.Order CreateOrderByCommand(OrderCreateCommand orderCreateCommand)
        {
            return new Entities.Order()
            {
                Id = orderCreateCommand.OrderId,
                Customer = this._custumerRepository.GetById(orderCreateCommand.CustumerId),
                CreatedDateTime = orderCreateCommand.Date,
                Details = orderCreateCommand.Details.Select(d => new Entities.OrderDetail()
                {
                    Id = Guid.NewGuid(),
                    Product = this._productRepository.GetById(d.ProductId),
                    Quantity = d.Quantity
                })
            };
        }


        public OrderCreateCommandHandler(IOrderRepository repository, ICustumerRepository custumerRepository, IProductRepository productRepository)
        {
            this._repository = repository;
            this._custumerRepository = custumerRepository;
            this._productRepository = productRepository;
        }

        protected override CommandResponse DoExecute(OrderCreateCommand command)
        {
            var order = CreateOrderByCommand(command);
            this._repository.Save(order);
            return new CommandResponse();
        }

        protected override ValidationResult DoValidate(OrderCreateCommand command)
        {
            var result = new ValidationResult();
            if (this._repository.Exists(command.CustumerId, command.Date))
                result.Errors.Add(new ValidationFailure("Pedido Duplicado", "O pedido já foi feito"));
            return result;
        }
    }
}
