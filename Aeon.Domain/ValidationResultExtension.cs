using FluentValidation.Results;

namespace Aeon.Domain
{
    public static class ValidationResultExtension
    {
        public static TCommandResponse CreateResponse<TCommandResponse>(this ValidationResult validationResult)
            where TCommandResponse : CommandResponse, new()
        {
            return new TCommandResponse()
            {
                ValidationResult = validationResult
            };
        }

        public static ValidationResult AddError(this ValidationResult validationResult, string errorCode, string errorMessage)
        {
            validationResult.Errors.Add(new ValidationFailure(errorCode, errorMessage));
            return validationResult;
        }

        public static ValidationResult AddError(this ValidationResult validationResult, string errorMessage)
        {
            return validationResult.AddError(string.Empty, errorMessage);
        }
    }
}
