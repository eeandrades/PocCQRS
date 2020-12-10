using FluentValidation.Results;
using MediatR;

namespace Aeon.Domain
{
    public abstract class Command<TCommandResponse> : IRequest<TCommandResponse>, IValidable
        where TCommandResponse : CommandResponse
    {
        public ValidationResult Validate()
        {
            return this.DoValidate();
        }

        public bool Validate(out ValidationResult validationResult)
        {
            validationResult = this.DoValidate();
            return validationResult.IsValid;
        }

        protected virtual ValidationResult DoValidate() => new ValidationResult();
    }


    public abstract class Command : Command<CommandResponse>
    {
    }
}
