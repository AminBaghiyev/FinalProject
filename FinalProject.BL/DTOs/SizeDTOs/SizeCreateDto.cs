using FluentValidation;

namespace FinalProject.BL.DTOs;

public record SizeCreateDto
{
    public string Value { get; set; }
}


public class SizeCreateDtoValidation : AbstractValidator<SizeCreateDto>
{
    public SizeCreateDtoValidation()
    {
        RuleFor(e => e.Value)
            .NotEmpty().NotNull().WithMessage("Value cannot be empty!");
    }
}