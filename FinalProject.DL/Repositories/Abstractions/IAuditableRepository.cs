using FinalProject.Core.Entities.Base;

namespace FinalProject.DL.Repositories.Abstractions;

public interface IAuditableRepository<T> : IRepository<T> where T : BaseAuditableEntity, new()
{
}
