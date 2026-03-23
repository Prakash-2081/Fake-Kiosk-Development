using Common.Common.Exception;
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
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IUnitOfWork db,ILogger<DepartmentService> logger)
        {
            _db = db;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<APIResponse> AddDepartmentAsync(DepartmentRequestDto request)
        {
            _logger.LogInformation("Add new Department process started with the Department Name :{DepartmentName}",request.DepartmentName);
            
            _logger.LogInformation("Validation Started.");
            var validationResult=request.Validate();

            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation Failed for department with Department Name: {DepartmentName}.Errors: {Errors} ", request.DepartmentName, validationResult.Errors);
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }
            _logger.LogInformation("Validation Passed");
            
            _logger.LogInformation("Check Department already Exists or not with department name: {DepartmentName}",request.DepartmentName);
            Department department=await _db.Department.FindByDepartmentNameAsync(request.DepartmentName);
            if (department != null)
            {
                _logger.LogError($"Department name: {request.DepartmentName} already exists. Exiting process");
                throw new Exception($"Deparment name {request.DepartmentName} already exist");
            }
            _logger.LogInformation($"Department doesnot exist with Department Name {request.DepartmentName} ");

            _logger.LogInformation("Department Creation Started");
            department = DepartmentMapper.ToDepartment(request);

            department=await _db.Department.AddAsync(department);
            _logger.LogInformation($"Department Information Saved with Id:{department.Id}");
            
            string result=await _db.SaveAsync();
            _logger.LogInformation("Database updated");

            _logger.LogInformation("Department creation process completed and returned success.");
            return ResponseHandler.GetSuccessResponse(DepartmentMapper.ToDepartmentResponseDto(department),result);

        }

        public async Task<APIResponse> UpdateDepartmentAsync(Guid id, DepartmentRequestDto request)
        {
            _logger.LogInformation($"Update department process started with ID {id}");

            _logger.LogInformation("Validation started");
            var validationResult = request.Validate();
            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Validation failed for department update with ID: {id}. Errors: {validationResult.Errors}");
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }
            _logger.LogInformation("Validation passed");

            _logger.LogInformation($"Search department to update with department id : {id}");
            Department department = await _db.Department.GetByIdAsync(id);

            if (department == null || department.IsDeleted)
            {
                _logger.LogError($"Department not found with department id : {id}");
                throw ResourceNotFoundException.Create<Department>(id);
            }

            _logger.LogInformation("Department mapping started:");
            department = DepartmentMapper.ToUpdateDepartment(department,request);

            _db.Department.UpdateAsync(department);
            _logger.LogInformation("Department information updated.");

            string result=await _db.SaveAsync();
            _logger.LogInformation("Database Updated");
            _logger.LogInformation("Department update process completed and returned success.");

            return ResponseHandler.GetSuccessResponse(DepartmentMapper.ToDepartmentResponseDto(department),result);
        }
        public async Task<APIResponse> DeleteDepartmentAsync(Guid id)
        {
            _logger.LogInformation($"Department deletion started with department id {id}");
            _logger.LogInformation($"Searching department to delete with department id: {id}");
            
            Department department = await _db.Department.GetByIdAsync(id);
            
            if (department ==null || department.IsDeleted) 
            {
                _logger.LogError($"Department not found to delete with department id: {id} and exist process");
                throw new Exception($"Department with id {id} not found");
            }
            department.IsDeleted = true;
            _db.Department.UpdateAsync(department);
           
            _logger.LogInformation($"Department delete with department id : {id}");
            string result=await _db.SaveAsync();
            _logger.LogInformation("Database Updated and returned Success");
            return ResponseHandler.GetSuccessResponse(DepartmentMapper.ToDepartmentResponseDto(department),result);
        }

        public async Task<APIResponse> GetDepartmentByIdAsync(Guid id)
        {
            _logger.LogInformation($"Searching Department with id {id}");
            Department department=await _db.Department.GetByIdAsync(id);
            if (department == null || department.IsDeleted)
            {
                _logger.LogInformation($"Department not found with ID: {id}");
                throw new Exception($"Department with id {id} not found");
            }

            _logger.LogInformation($"Returned department: {department.DepartmentName}");
            return ResponseHandler.GetSuccessResponse(department);
        }
        public async Task<APIResponse> GetAllDepartmentAsync()
        {
            _logger.LogInformation("Loading all departments.");
            var departments= _db.Department.GetAllAsync();
            var activeDepartments = departments.Result.Where(x => x.IsDeleted == false);

            var responseDtoList = activeDepartments.
                Select(x => DepartmentMapper.ToDepartmentResponseDto(x))
                .ToList();
            _logger.LogInformation($"Returns all Departments ({responseDtoList.Count}) and success");

            return ResponseHandler.GetSuccessResponse(responseDtoList);
        }


    }
}
