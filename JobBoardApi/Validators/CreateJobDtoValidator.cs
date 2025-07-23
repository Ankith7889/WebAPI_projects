using FluentValidation;
using JobBoardApi.DTOs;

namespace JobBoardApi.Validators
{
    public class CreateJobDtoValidator : AbstractValidator<CreateJobDto>
    {
        public CreateJobDtoValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Job title is required")
            .MaximumLength(100).WithMessage("Job title cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MinimumLength(10).WithMessage("Description must be at least 10 characters");
        }
    }
}
