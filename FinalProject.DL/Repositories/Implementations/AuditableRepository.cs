using FinalProject.Core.Entities.Base;
using FinalProject.DL.Contexts;
using FinalProject.DL.Repositories.Abstractions;

namespace FinalProject.DL.Repositories.Implementations;

public class AuditableRepository<T> : Repository<T>, IAuditableRepository<T> where T : BaseAuditableEntity, new()
{
    public AuditableRepository(AppDbContext context) : base(context) { }

    public override async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow.AddHours(4);
        await base.CreateAsync(entity);
    }

    public override void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
        base.Update(entity);
    }

    public override void Recover(T entity)
    {
        entity.DeletedAt = null;
        entity.DeletedById = null;
        base.Recover(entity);
    }

    public override void SoftDelete(T entity)
    {
        entity.DeletedAt = DateTime.UtcNow.AddHours(4);
        base.SoftDelete(entity);
    }
}
