using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Services.Abstractions;

public interface IProductService
{
    Task<Product> GetByIdAsync(int id);
    Task<ICollection<ProductListItemDto>> GetAllAsync();
    Task<Product> CreateAsync(ProductCreateDto dto, string username);
    Task<Product> UpdateAsync(ProductUpdateDto dto, string username);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id, string username);
    Task RecoverAsync(int id);
    Task<int> SaveChangesAsync();
}
