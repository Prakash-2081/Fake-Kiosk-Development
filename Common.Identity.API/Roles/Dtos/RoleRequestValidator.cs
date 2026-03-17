using FluentValidation;

namespace Common.Identity.API.Roles.Dtos
{
    public class RoleRequestValidator:AbstractValidator<RoleRequestDto>
    {
        public RoleRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role is Required")
                .MaximumLength(50).WithMessage("Name length should be less than or equal to 50 characters")
                .Must(x=>x!= "Admin").WithMessage("Admin name is not allowed to change");

            RuleFor(x => x.ModulePermissionIds)
                .Must(x => x != null && x.Any())
                .WithMessage("At least one permission is required");
        }
    }
}
