namespace FinalProject.Core.Entities.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
    public AppUser CreatedBy { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedAt { get; set; }
    public AppUser? UpdatedBy { get; set; }
    public string? UpdatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public AppUser? DeletedBy { get; set; }
    public string? DeletedById { get; set; }
    public DateTime? DeletedAt { get; set; }
}
