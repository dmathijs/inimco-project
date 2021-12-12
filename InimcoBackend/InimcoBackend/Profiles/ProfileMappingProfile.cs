using AutoMapper;
using InimcoBackend.Entities.Enums;
using InimcoBackend.Extensions;
using InimcoBackend.Models;
using InimcoBackend.Models.ProfileRetrieval;

namespace InimcoBackend.Profiles
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<ProfileCreateDto, Entities.Profile>();
            CreateMap<Entities.Profile, ProfileRetrievalDto>();

            CreateMap<Entities.Profile, ProfileWrapperRetrievalDto>()
                .ForMember(pwrd => pwrd.OriginalProfile, conf => conf.MapFrom(p => p))
                .ForMember(pwrd => pwrd.NumberOfVowelsInFirstAndLastName, conf => conf.MapFrom(p => $"{p.FirstName}{p.LastName}".CountVowels()))
                .ForMember(pwrd => pwrd.NumberOfConsonantsInFirstAndLastName, conf => conf.MapFrom(p => $"{p.FirstName}{p.LastName}".CountConsenants()));

            CreateMap<Entities.ProfileSocialNetwork, ProfileSocialNetworkRetrievalDto>()
                .ForMember(psmr => psmr.Type, conf => conf.MapFrom(psn => psn.Type.GetName()));

            CreateMap<ProfileSocialMediaCreateDto, Entities.ProfileSocialNetwork>();
        }
    }
}
