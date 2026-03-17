using Common.Common.Response;
using Common.Identity.API.Roles.Contracts;
using Common.Identity.API.Roles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Identity.API.Roles
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }
        [HttpPost]
        public async Task<APIResponse> AddRoleAsync([FromBody] RoleRequestDto requestDto)
        {
            var apiResponse=await _roleService.AddRoleAsync(requestDto);
            return apiResponse;
        }
        [HttpPost("{id}")]
        public async Task<APIResponse> UpdateRoleAsync(Guid id, [FromBody] RoleRequestDto requestDto)
        {
            var apiResponse = await _roleService.UpdateRoleAsync(id, requestDto);
            return apiResponse;
        }
        [HttpDelete("{id}")]
        public async Task<APIResponse> DeleteRoleAsync(Guid id)
        {
            var apiResponse=await _roleService.DeleteRoleAsync(id);
            return apiResponse; 
        }
        [HttpGet]
        public async Task<APIResponse> GetAllRoleAsync()
        {
            var apiReponse=await _roleService.GetAllRoleAsync();    
            return apiReponse;
        }
        [HttpGet("{id}")]
        public async Task<APIResponse> GetRoleByIdAsync(Guid id)
        {
            var apiResponse = await _roleService.GetRoleByIdAsync(id);
            return apiResponse;
        }

    }
}
