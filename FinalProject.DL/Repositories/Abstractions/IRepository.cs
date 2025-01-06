using FinalProject.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DL.Repositories.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdAsNoTrackingAsync(int id);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Recover(T entity);
    void SoftDelete(T entity);
    void HardDelete(T entity);
    Task<int> SaveChangesAsync();
}
