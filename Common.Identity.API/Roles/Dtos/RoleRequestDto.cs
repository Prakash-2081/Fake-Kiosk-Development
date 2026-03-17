using FluentValidation.Results;

namespace Common.Identity.API.Roles.Dtos
{
    public class RoleRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public List<string>? ModulePermissionIds { get; set; }

        private static RoleRequestValidator _validator=new RoleRequestValidator();
        public ValidationResult Validate()
        {
            return _validator.Validate(this);   
        } 

    }
}
