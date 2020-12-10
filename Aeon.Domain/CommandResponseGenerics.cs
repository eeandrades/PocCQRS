using FluentValidation.Results;

namespace Aeon.Domain
{
    public class CommandResponse<TContext> : CommandResponse
    {
        public TContext Context { get; set; }

        public CommandResponse()
        {

        }
        public CommandResponse(ValidationResult validationResult, TContext context) :
            base(validationResult)
        {
            this.Context = context;
        }

        public CommandResponse(TContext context) :
            base()
        {
            this.Context = context;
        }
    }
}
