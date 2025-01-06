using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Services.Abstractions;

public interface ISizeService
{
    Task<Size> GetByIdAsync(int id);
    Task<ICollection<SizeListItemDto>> GetAllAsync();
    Task<Size> CreateAsync(SizeCreateDto dto, string username);
    Task<Size> UpdateAsync(SizeUpdateDto dto, string username);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id, string username);
    Task RecoverAsync(int id);
    Task<int> SaveChangesAsync();
}
