namespace JobBoardApi.Validators
{
    using FluentValidation;
    using JobBoardApi.DTOs;

    public class JobApplicationDtoValidator : AbstractValidator<JobApplicationDto>
    {
        public JobApplicationDtoValidator()
        {
            RuleFor(x => x.JobId)
                .GreaterThan(0).WithMessage("Job ID must be greater than zero.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User ID must be greater than zero.");
        }
    }
}
