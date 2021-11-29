using AutoMapper;
using VsSdk.UForm;
using DomainError = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.UForms.Mapping
{
    internal class ErrorToDomainErrorMappinProfile: Profile
    {
        public ErrorToDomainErrorMappinProfile()
        {
            CreateMap<Error, DomainError.Error>();
        }
    }
}
