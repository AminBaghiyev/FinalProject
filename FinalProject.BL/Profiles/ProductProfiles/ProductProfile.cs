using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductListItemDto, Product>().ReverseMap();

        CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.ColorId == 0 ? null : src.ColorId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId == 0 ? null : src.SizeId))
            .ReverseMap();

        CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedById, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedById, opt => opt.Ignore())
            .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.ColorId == 0 ? null : src.ColorId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId == 0 ? null : src.SizeId))
            .ReverseMap();
    }
}
