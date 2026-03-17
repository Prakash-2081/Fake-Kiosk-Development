using FluentValidation;

namespace Common.Identity.API.Departments.Dtos
{
    public class DepartmentRequestValidator:AbstractValidator<DepartmentRequestDto>
    {
        public DepartmentRequestValidator()
        {
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Department Name is Required")
                .MaximumLength(50).WithMessage("Deparment Name should not Exceed 50 char.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is Required")
                .MaximumLength(250).WithMessage("Description should not exceed 250 char");
        }
    }
}
