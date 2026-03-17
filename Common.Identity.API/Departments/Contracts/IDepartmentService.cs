using Common.Common.Response;
using Common.Identity.API.Departments.Dtos;

namespace Common.Identity.API.Departments.Contracts
{
    public interface IDepartmentService
    {
        Task<APIResponse> AddDepartmentAsync(DepartmentRequestDto request);
        Task<APIResponse> UpdateDepartmentAsync(Guid id, DepartmentRequestDto request);
        Task<APIResponse> DeleteDepartmentAsync(Guid id);
        Task<APIResponse> GetDepartmentByIdAsync(Guid id);
        Task<APIResponse> GetAllDepartmentAsync();
    }
}
