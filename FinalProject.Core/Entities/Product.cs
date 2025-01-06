using FinalProject.Core.Entities.Base;

namespace FinalProject.Core.Entities;

public class Product : BaseAuditableEntity
{
    public string ThumbnailPath { get; set; }
    public int Group { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal DiscountedPrice { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public Color? Color { get; set; }
    public int? ColorId { get; set; }
    public Size? Size { get; set; }
    public int? SizeId { get; set; }
}
