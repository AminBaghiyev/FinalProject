using FluentValidation;

namespace FinalProject.BL.DTOs;

public record CategoryCreateDto
{
    public string Title { get; set; }
}


public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidation()
    {
        RuleFor(e => e.Title)
            .NotEmpty().NotNull().WithMessage("Title cannot be empty!");
    }
}