using FluentValidation;

namespace FinalProject.BL.DTOs;

public record ColorUpdateDto
{
    public int Id { get; set; }
    public string Value { get; set; }
}

public class ColorUpdateDtoValidation : AbstractValidator<ColorUpdateDto>
{
    public ColorUpdateDtoValidation()
    {
        RuleFor(e => e.Id)
            .NotEmpty().NotNull().GreaterThan(0).WithMessage("Id must be a positive number!");

        RuleFor(e => e.Value)
            .NotEmpty().NotNull().WithMessage("Value cannot be empty!");
    }
}