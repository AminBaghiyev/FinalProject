using FluentValidation;

namespace FinalProject.BL.DTOs;

public record CategoryUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class CategoryUpdateDtoValidation : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidation()
    {
        RuleFor(e => e.Id)
            .NotEmpty().NotNull().GreaterThan(0).WithMessage("Id must be a positive number!");

        RuleFor(e => e.Title)
            .NotEmpty().NotNull().WithMessage("Title cannot be empty!");
    }
}