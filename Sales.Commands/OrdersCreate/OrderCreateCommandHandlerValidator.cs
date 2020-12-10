//using Aeon.Domain;
//using FluentValidation.Results;
//using MediatR;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Sales.Commands.OrdersCreate
//{
//    public class OrderCreateCommandHandler : CommandHandler<OrderCreateCommand>, IOrderCreateCommandHandler
//    {
//        protected override ValidationResult DoExecute(OrderCreateCommand command)
//        {
//            return new ValidationResult();
//        }

//        //async Task<ValidationResult> IRequestHandler<OrderCreateCommand, ValidationResult>.Handle(OrderCreateCommand request, CancellationToken cancellationToken)
//        //{
//        //    if (request.Validate(out var validationResult))
//        //        return await Task<ValidationResult>.Run(() => new ValidationResult());
//        //    else
//        //    {
//        //        return await Task<ValidationResult>.Run(() => validationResult);
//        //    }
//        //}
//    }
//}
