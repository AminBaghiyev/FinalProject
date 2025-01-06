using FinalProject.Core.Entities.Base;
using FinalProject.DL.Contexts;
using FinalProject.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DL.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public virtual async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        Table.Update(entity);
    }

    public virtual void Recover(T entity)
    {
        entity.IsDeleted = false;
    }

    public virtual void SoftDelete(T entity)
    {
        entity.IsDeleted = true;
    }

    public void HardDelete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();

    public async Task<T?> GetByIdAsNoTrackingAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<T?> GetByIdAsync(int id) => await Table.FindAsync(id);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
