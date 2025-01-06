using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using FinalProject.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.BL.Services.Concretes;

public class ColorService : IColorService
{
    readonly UserManager<AppUser> _userManager;
    readonly IAuditableRepository<Color> _repository;
    readonly IMapper _mapper;

    public ColorService(IAuditableRepository<Color> repository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Color> CreateAsync(ColorCreateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Color color = _mapper.Map<Color>(dto);
        color.CreatedById = user.Id;

        await _repository.CreateAsync(color);
        return color;
    }

    public async Task<Color> UpdateAsync(ColorUpdateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Color oldColor = await GetByIdAsync(dto.Id);
        Color newColor = _mapper.Map(dto, oldColor);
        newColor.UpdatedById = user.Id;

        _repository.Update(newColor);
        return newColor;
    }

    public async Task RecoverAsync(int id)
    {
        Color color = await GetByIdAsync(id);

        _repository.Recover(color);
    }

    public async Task SoftDeleteAsync(int id, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Color color = await GetByIdAsync(id);
        color.DeletedById = user.Id;

        _repository.SoftDelete(color);
    }

    public async Task HardDeleteAsync(int id)
    {
        Color color = await GetByIdAsync(id);

        _repository.HardDelete(color);
    }

    public async Task<ICollection<ColorListItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<ColorListItemDto>>(await _repository.GetAllAsync());
    }

    public async Task<Color> GetByIdAsync(int id)
    {
        return
            await _repository.GetByIdAsync(id) ??
            throw new EntityNotFoundException();
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
