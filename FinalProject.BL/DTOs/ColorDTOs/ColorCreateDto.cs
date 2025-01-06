using FluentValidation;

namespace FinalProject.BL.DTOs;

public record ColorCreateDto
{
    public string Value { get; set; }
}


public class ColorCreateDtoValidation : AbstractValidator<ColorCreateDto>
{
    public ColorCreateDtoValidation()
    {
        RuleFor(e => e.Value)
            .NotEmpty().NotNull().WithMessage("Value cannot be empty!");
    }
}