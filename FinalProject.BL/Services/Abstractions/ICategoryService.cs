using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Services.Abstractions;

public interface ICategoryService
{
    Task<Category> GetByIdAsync(int id);
    Task<ICollection<CategoryListItemDto>> GetAllAsync();
    Task<Category> CreateAsync(CategoryCreateDto dto, string username);
    Task<Category> UpdateAsync(CategoryUpdateDto dto, string username);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id, string username);
    Task RecoverAsync(int id);
    Task<int> SaveChangesAsync();
}
