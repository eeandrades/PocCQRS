using FluentValidation;
using System.Linq;

namespace Sales.Commands.OrdersCreate
{
    public class OrderCreateCommandValidator : AbstractValidator<OrderCreateCommand>
    {
        public OrderCreateCommandValidator()
        {
            //RuleFor(c=>c.Details)

            RuleFor(c => c.Details.Any())
                .Equal(true).WithMessage("Informe pelo menos um item para o pedido");
        }
    }
}
