using FinalProject.Core.Entities.Base;

namespace FinalProject.Core.Entities;

public class Color : BaseAuditableEntity
{
    public string Value { get; set; }
    public ICollection<Product> Products { get; set; }
}
