using Common.Common.Response;
using Common.Identity.API.Permissions.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Common.Identity.API.Permissions
{
    [Route("api/permission")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllPermissionAsync()
        {
            var apiResponse = await _permissionService.GetAllPermissionAsync();
            return apiResponse;
        }
    }
}
