using FinalProject.Core.Entities.Base;

namespace FinalProject.Core.Entities;

public class Size : BaseAuditableEntity
{
    public string Value { get; set; }
    public ICollection<Product> Products { get; set; }
}
