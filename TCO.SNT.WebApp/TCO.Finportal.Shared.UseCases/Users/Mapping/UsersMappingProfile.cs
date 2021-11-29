using AutoMapper;
using TCO.Finportal.Shared.Entities;
using TCO.Finportal.Shared.UseCases.Users.Shared;

namespace TCO.Finportal.Shared.UseCases.Users.Mapping
{
    internal class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<EsfUserProfile, EsfUserProfileDto>()
                .ForMember(
                    dest => dest.UsernameSpecified,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.UsernameSecretName)))
                .ForMember(
                    dest => dest.PasswordSpecified,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.PasswordSecretName)))
                .ForMember(
                    dest => dest.AuthCertificateUploaded,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Base64AuthCertificateSecretName)))
                .ForMember(
                    dest => dest.SignCertificateUploaded,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.Base64SignCertificateSecretName) &&
                        !string.IsNullOrEmpty(src.SignRSAKeyName)))
                .ForMember(
                    dest => dest.ReadyForAuth,
                    opt => opt.MapFrom(src => src.ReadyForAuth()))
                .ForMember(
                    dest => dest.ReadyForSign,
                    opt => opt.MapFrom(src => src.ReadyForSign()));
        }
    }
}
