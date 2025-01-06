using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.ExternalServices.Abstractions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using FinalProject.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalProject.BL.Services.Concretes;

public class AccountService : IAccountService
{
    readonly UserManager<AppUser> _userManager;
    readonly IJWTTokenService _jwtTokenService;
    readonly IMapper _mapper;

    public AccountService(UserManager<AppUser> userManager, IJWTTokenService jwtTokenService, IMapper mapper)
    {
        _mapper = mapper;
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }

    public async Task RegisterAsync(AppUserRegisterDto dto)
    {
        AppUser user = _mapper.Map<AppUser>(dto);

        if (await _userManager.FindByEmailAsync(user.Email) is not null)
            throw new UserExistsException("User with this email already exists!");

        if (await _userManager.FindByNameAsync(user.UserName) is not null)
            throw new UserExistsException("User with this username already exists!");

        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) throw new UserCouldNotBeCreatedException();

        await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
    }

    public async Task<string> LoginAsync(AppUserLoginDto dto)
    {
        AppUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new EntityNotFoundException("Something went wrong!");

        if (!await _userManager.CheckPasswordAsync(user, dto.Password)) throw new UserCredentialsCouldNotBeVerifiedException();

        IEnumerable<string> roles = await _userManager.GetRolesAsync(user);
        string role = roles.FirstOrDefault() ?? UserRoles.User.ToString();

        IEnumerable<Claim> claims =
        [
            new("FirstName", user.FirstName ?? "null"),
            new("LastName", user.LastName ?? "null"),
            new("UserName", user.UserName ?? "null"),
            new("Email", user.Email ?? "null"),
            new(ClaimTypes.Role, role)
        ];

        return _jwtTokenService.GenerateToken(claims);
    }

    public async Task<ICollection<AppUserListItemDto>> GetAllUsers()
    {
        return _mapper.Map<ICollection<AppUserListItemDto>>(await _userManager.Users.ToListAsync());
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) ?? throw new EntityNotFoundException();
    }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        return await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
        AppUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new EntityNotFoundException("Something went wrong!");

        IdentityResult result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (!result.Succeeded)
            throw new UserPasswordCouldNotBeChangedException();

        return true;
    }
}
