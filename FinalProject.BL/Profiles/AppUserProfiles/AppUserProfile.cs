using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Profiles;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
        CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
        CreateMap<AppUserListItemDto, AppUser>().ReverseMap();
    }
}
