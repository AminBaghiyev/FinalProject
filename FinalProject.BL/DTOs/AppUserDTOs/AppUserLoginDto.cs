using FluentValidation;

namespace FinalProject.BL.DTOs;

public record AppUserLoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class AppUserLoginDtoValidation : AbstractValidator<AppUserLoginDto>
{
    public AppUserLoginDtoValidation()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().NotNull().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.Password)
            .NotEmpty().NotNull().WithMessage("The password cannot be empty!")
            .MinimumLength(4).WithMessage("The password must be at least 4 symbols long!");
    }
}