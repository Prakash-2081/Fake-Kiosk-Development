using FluentValidation.Results;

namespace Common.Identity.API.Departments.Dtos
{
    public class DepartmentRequestDto
    {
        private static DepartmentRequestValidator _validator = new DepartmentRequestValidator();
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }
    }
}
