using Common.Common.Response;
using Common.Identity.API.Departments.Contracts;
using Common.Identity.API.Departments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Common.Identity.API.Departments
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        public async Task<APIResponse> AddDepartmentAsync(DepartmentRequestDto requestDto)
        {
            var apiResponse = await _departmentService.AddDepartmentAsync(requestDto);
            return apiResponse;
        }

        [HttpPut("{id}")]
        public async Task<APIResponse> UpdateDepartmentAsync(Guid id, DepartmentRequestDto requestDto)
        {
            var apiResponse = await _departmentService.UpdateDepartmentAsync(id, requestDto);
            return apiResponse;
        }
        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteDepartmentAsync(Guid id)
        {
            var apiResponse = await _departmentService.DeleteDepartmentAsync(id);
            return apiResponse;
        }
        [HttpGet("{id}")]
        public async Task<APIResponse> GetDepartmentAsync(Guid id)
        {
            var apiResponse = await _departmentService.GetDepartmentByIdAsync(id);
            return apiResponse;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllDepartmentAsync()
        {
            var apiResponse = await _departmentService.GetAllDepartmentAsync();
            return apiResponse;
        }

    }
}
