using Common.Common.Handlers;
using Common.Common.Response;
using Common.Identity.API.Data.Contracts;
using Common.Identity.API.Departments.Contracts;
using Common.Identity.API.Departments.Dtos;

namespace Common.Identity.API.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _db;

        public DepartmentService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<APIResponse> AddDepartmentAsync(DepartmentRequestDto request)
        {
            var validationResult=request.Validate();
            if (!validationResult.IsValid)
            {
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }
            Department department=await _db.Department.FindByDepartmentNameAsync(request.DepartmentName);
            if (department != null)
            {
                throw new Exception($"Deparment name {request.DepartmentName} already exist");
            }
            department = DepartmentMapper.ToDepartment(request);
            department=await _db.Department.AddAsync(department);
            string result=await _db.SaveAsync();
            return ResponseHandler.GetSuccessResponse(DepartmentMapper.ToDepartmentResponseDto(department),result);

        }

        public async Task<APIResponse> UpdateDepartmentAsync(Guid id, DepartmentRequestDto request)
        {
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }
            Department department = await _db.Department.GetByIdAsync(id);
            department = DepartmentMapper.ToUpdateDepartment(department,request);
            _db.Department.UpdateAsync(department);
            string result=await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(DepartmentMapper.ToDepartmentResponseDto(department),result);
        }
        public async Task<APIResponse> DeleteDepartmentAsync(Guid id)
        {
            Department department = await _db.Department.GetByIdAsync(id);
            if (department ==null || department.IsDeleted) 
            {
                throw new Exception($"Department with id {id} not found");
            }
            department.IsDeleted = true;
            _db.Department.UpdateAsync(department);
            string result=await _db.SaveAsync();
            return ResponseHandler.GetSuccessResponse(DepartmentMapper.ToDepartmentResponseDto(department),result);
        }

        public async Task<APIResponse> GetDepartmentByIdAsync(Guid id)
        {
            Department department=await _db.Department.GetByIdAsync(id);
            if (department == null || department.IsDeleted)
            {
                throw new Exception($"Department with id {id} not found");
            }
            return ResponseHandler.GetSuccessResponse(department);
        }
        public async Task<APIResponse> GetAllDepartmentAsync()
        {
            var departments= _db.Department.GetAllAsync();
            var activeDepartments = departments.Result.Where(x => x.IsDeleted == false);

            var responseDtoList = activeDepartments.
                Select(x => DepartmentMapper.ToDepartmentResponseDto(x))
                .ToList();
            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }


    }
}
