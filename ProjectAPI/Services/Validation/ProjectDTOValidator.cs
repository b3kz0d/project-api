using FluentValidation;
using ProjectAPI.DTOs;

namespace ProjectAPI.Services.Validation
{
    public class ProjectDTOValidator : AbstractValidator<ProjectDTO>
    {
        public ProjectDTOValidator()
        {
            RuleFor(x => x.WorkAt).MaximumLength(2).WithMessage("WorkAt must not exceed 2 characters.");
        }
    }
}
