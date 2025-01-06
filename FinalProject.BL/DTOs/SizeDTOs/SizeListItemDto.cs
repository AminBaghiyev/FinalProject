namespace FinalProject.BL.DTOs;

public record SizeListItemDto
{
    public int Id { get; set; }
    public string Value { get; set; }
    public bool IsDeleted { get; set; }
}
