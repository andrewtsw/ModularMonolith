using FluentValidation;
using VsSdk.Version;

namespace TCO.SNT.UseCases.ErrorCode.Commands.ImportErrorCodes
{
    internal class ErrorCodeValidator : AbstractValidator<errorDescription>
    {
        public ErrorCodeValidator()
        {
            RuleFor(x => x.errorCode).NotEmpty();

            RuleFor(x => x.description).NotEmpty();
        }
    }
}
