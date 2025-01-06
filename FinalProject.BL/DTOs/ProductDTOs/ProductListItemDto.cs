using FinalProject.Core.Entities;

namespace FinalProject.BL.DTOs;

public record ProductListItemDto
{
    public int Id { get; set; }
    public int Group { get; set; }
    public string Title { get; set; }
    public decimal DiscountedPrice { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public bool IsDeleted { get; set; }
}
