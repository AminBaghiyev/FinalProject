using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using FinalProject.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.BL.Services.Concretes;

public class SizeService : ISizeService
{
    readonly UserManager<AppUser> _userManager;
    readonly IAuditableRepository<Size> _repository;
    readonly IMapper _mapper;

    public SizeService(IAuditableRepository<Size> repository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Size> CreateAsync(SizeCreateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Size size = _mapper.Map<Size>(dto);
        size.CreatedById = user.Id;

        await _repository.CreateAsync(size);
        return size;
    }

    public async Task<Size> UpdateAsync(SizeUpdateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Size oldSize = await GetByIdAsync(dto.Id);
        Size newSize = _mapper.Map(dto, oldSize);
        newSize.UpdatedById = user.Id;

        _repository.Update(newSize);
        return newSize;
    }

    public async Task RecoverAsync(int id)
    {
        Size size = await GetByIdAsync(id);

        _repository.Recover(size);
    }

    public async Task SoftDeleteAsync(int id, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Size size = await GetByIdAsync(id);
        size.DeletedById = user.Id;

        _repository.SoftDelete(size);
    }

    public async Task HardDeleteAsync(int id)
    {
        Size size = await GetByIdAsync(id);

        _repository.HardDelete(size);
    }

    public async Task<ICollection<SizeListItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<SizeListItemDto>>(await _repository.GetAllAsync());
    }

    public async Task<Size> GetByIdAsync(int id)
    {
        return
            await _repository.GetByIdAsync(id) ??
            throw new EntityNotFoundException();
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
