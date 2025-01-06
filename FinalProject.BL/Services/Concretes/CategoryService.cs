using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using FinalProject.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.BL.Services.Concretes;

public class CategoryService : ICategoryService
{
    readonly UserManager<AppUser> _userManager;
    readonly IAuditableRepository<Category> _repository;
    readonly IMapper _mapper;

    public CategoryService(IAuditableRepository<Category> repository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Category> CreateAsync(CategoryCreateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Category category = _mapper.Map<Category>(dto);
        category.CreatedById = user.Id;

        await _repository.CreateAsync(category);
        return category;
    }

    public async Task<Category> UpdateAsync(CategoryUpdateDto dto, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Category oldCategory = await GetByIdAsync(dto.Id);
        Category newCategory = _mapper.Map(dto, oldCategory);
        newCategory.UpdatedById = user.Id;

        _repository.Update(newCategory);
        return newCategory;
    }

    public async Task RecoverAsync(int id)
    {
        Category category = await GetByIdAsync(id);

        _repository.Recover(category);
    }

    public async Task SoftDeleteAsync(int id, string username)
    {
        AppUser user = await _userManager.FindByNameAsync(username) ?? throw new EntityNotFoundException();
        Category category = await GetByIdAsync(id);
        category.DeletedById = user.Id;

        _repository.SoftDelete(category);
    }

    public async Task HardDeleteAsync(int id)
    {
        Category category = await GetByIdAsync(id);

        _repository.HardDelete(category);
    }

    public async Task<ICollection<CategoryListItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<CategoryListItemDto>>(await _repository.GetAllAsync());
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return
            await _repository.GetByIdAsync(id) ??
            throw new EntityNotFoundException();
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
