using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Services.Abstractions;

public interface IAccountService
{
    Task RegisterAsync(AppUserRegisterDto dto);
    Task<string> LoginAsync(AppUserLoginDto dto);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
    Task<ICollection<AppUserListItemDto>> GetAllUsers();
    Task<AppUser> GetUserByEmailAsync(string email);
    Task<AppUser> GetUserByUsernameAsync(string username);
}
