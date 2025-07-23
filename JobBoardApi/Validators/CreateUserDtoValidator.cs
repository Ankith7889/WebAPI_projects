using FluentValidation;
using JobBoardApi.DTOs;

namespace JobBoardApi.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.Role)
                .Must(role => role == null || new[] { "User", "Employer", "Admin" }.Contains(role))
                .WithMessage("Role must be User, Employer, or Admin");
        }
    }
}
