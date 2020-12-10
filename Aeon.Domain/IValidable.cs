using FluentValidation.Results;

namespace Aeon.Domain
{
    public interface IValidable
    {
        ValidationResult Validate();

        bool Validate(out ValidationResult validationResult);
    }
}
