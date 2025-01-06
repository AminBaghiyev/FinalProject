using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Profiles;

public class SizeProfile : Profile
{
    public SizeProfile()
    {
        CreateMap<SizeListItemDto, Size>().ReverseMap();
        CreateMap<SizeCreateDto, Size>().ReverseMap();

        CreateMap<SizeUpdateDto, Size>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedById, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedById, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
            .ReverseMap();
    }
}
