using FluentValidation;

namespace FinalProject.BL.DTOs;

public class ChangePasswordDto
{
    public string UserName { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}

public class ChangePasswordDtoValidation : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidation()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().NotNull().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.OldPassword)
            .NotEmpty().NotNull().WithMessage("Old password cannot be empty!")
            .MinimumLength(4).WithMessage("Old password must be at least 4 symbols long!");

        RuleFor(e => e.NewPassword)
            .NotEmpty().NotNull().WithMessage("New password cannot be empty!")
            .MinimumLength(4).WithMessage("New password must be at least 4 symbols long!")
            .Equal(e => e.ConfirmPassword).WithMessage("Passwords do not match!");
    }
}