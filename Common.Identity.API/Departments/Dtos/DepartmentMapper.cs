namespace Common.Identity.API.Departments.Dtos
{
    public static class DepartmentMapper
    {
        public static Department ToDepartment(DepartmentRequestDto request)
        {
            return new Department
            {
                DepartmentName = request.DepartmentName,
                Description = request.Description,
                CreatedDate=DateTimeOffset.UtcNow   
            };
        }
        public static Department ToUpdateDepartment(Department department,DepartmentRequestDto request)
        {
            department.DepartmentName = request.DepartmentName;
            department.Description = request.Description;
            department.ModifiedDate=DateTimeOffset.UtcNow;
            return department;
        }
        public static DepartmentResponseDto ToDepartmentResponseDto(Department department)
        {
            return new DepartmentResponseDto
            {
                DepartmentId = department.Id,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
        }
    }
}
