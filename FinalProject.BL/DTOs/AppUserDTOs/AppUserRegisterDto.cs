using FluentValidation;

namespace FinalProject.BL.DTOs;

public record AppUserRegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class AppUserRegisterDtoValidation : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterDtoValidation()
    {
        RuleFor(e => e.FirstName)
            .NotEmpty().NotNull().WithMessage("Firstname cannot be empty!")
            .MinimumLength(2).WithMessage("The firstname must be at least 2 letters long!")
            .Matches(@"^[A-Za-z\s]*$").WithMessage("Firstname should only contain letters!");

        RuleFor(e => e.LastName)
            .NotEmpty().NotNull().WithMessage("Lastname cannot be empty!")
            .MinimumLength(3).WithMessage("The lastname must be at least 3 letters long!")
            .Matches(@"^[A-Za-z\s]*$").WithMessage("Lastname should only contain letters!");

        RuleFor(e => e.UserName)
            .NotEmpty().NotNull().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.Email)
            .NotEmpty().NotNull().WithMessage("Email cannot be empty!")
            .EmailAddress().WithMessage("A valid email is required!");

        RuleFor(e => e.Password)
            .NotEmpty().NotNull().WithMessage("The password cannot be empty!")
            .MinimumLength(4).WithMessage("The password must be at least 4 symbols long!")
            .Equal(e => e.ConfirmPassword).WithMessage("Passwords do not match!");
    }
}