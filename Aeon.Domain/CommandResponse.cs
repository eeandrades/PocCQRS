using FluentValidation.Results;
using System.Collections.Generic;

namespace Aeon.Domain
{
    public class CommandResponse
    {
        public ValidationResult ValidationResult { get; init; }

        public CommandResponse()
        {
            this.ValidationResult = new ValidationResult();
        }

        public CommandResponse(ValidationResult validationResult)
        {
            this.ValidationResult = validationResult ?? throw new System.ArgumentNullException(nameof(validationResult));
        }

        public bool IsValid => this.ValidationResult?.IsValid ?? true;

        public bool IsInvalid => !this.IsValid;

        public IEnumerable<ValidationFailure> Errors => this.ValidationResult?.Errors ?? System.Array.Empty<ValidationFailure>();

        public void AddError(ValidationFailure validationFailure)
        {
            this.ValidationResult.Errors.Add(validationFailure);
        }
    }
}
