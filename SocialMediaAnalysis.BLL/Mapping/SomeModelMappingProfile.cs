/*
using AutoMapper;
using SocialMediaAnalysis.BLL.Models.SomeModel;
using SocialMediaAnalysis.DAL.Entities;

namespace SocialMediaAnalysis.BLL.Mapping;

public class SomeModelMappingProfile : Profile
{
    public SomeModelMappingProfile()
    {
        CreateMap<SomeModel, SomeEntity>()
            .ForMember(g => g.CreationDate, cfg => cfg.MapFrom(gcm => DateTime.UtcNow));
    }
}

THIS IS AN EXAMPLE OF THE MAPPING PROFILE

*/