using FinalProject.Core.Entities.Base;

namespace FinalProject.Core.Entities;

public class Category : BaseAuditableEntity
{
    public string Title { get; set; }
    public ICollection<Product> Products { get; set; }
}
