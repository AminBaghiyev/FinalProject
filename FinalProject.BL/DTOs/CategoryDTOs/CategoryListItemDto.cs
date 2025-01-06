namespace FinalProject.BL.DTOs;

public record CategoryListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}
