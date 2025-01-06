using FinalProject.BL.DTOs;
using FinalProject.Core.Entities;

namespace FinalProject.BL.Services.Abstractions;

public interface IColorService
{
    Task<Color> GetByIdAsync(int id);
    Task<ICollection<ColorListItemDto>> GetAllAsync();
    Task<Color> CreateAsync(ColorCreateDto dto, string username);
    Task<Color> UpdateAsync(ColorUpdateDto dto, string username);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id, string username);
    Task RecoverAsync(int id);
    Task<int> SaveChangesAsync();
}
