using FluentValidation;

namespace FinalProject.BL.DTOs;

public record SizeUpdateDto
{
    public int Id { get; set; }
    public string Value { get; set; }
}

public class SizeUpdateDtoValidation : AbstractValidator<SizeUpdateDto>
{
    public SizeUpdateDtoValidation()
    {
        RuleFor(e => e.Id)
            .NotEmpty().NotNull().GreaterThan(0).WithMessage("Id must be a positive number!");

        RuleFor(e => e.Value)
            .NotEmpty().NotNull().WithMessage("Value cannot be empty!");
    }
}