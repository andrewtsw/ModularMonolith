using AutoMapper;
using EsfApiSdk.Snt;
using DomainError = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class ErrorToDomainErrorMappinProfile: Profile
    {
        public ErrorToDomainErrorMappinProfile()
        {
            CreateMap<Error, DomainError.Error>();
        }
    }
}
