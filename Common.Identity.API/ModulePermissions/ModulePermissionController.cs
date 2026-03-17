using Common.Common.Response;
using Common.Identity.API.ModulePermissions.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Identity.API.ModulePermissions
{
    [Route("api/module-permissions")]
    [ApiController]
    public class ModulePermissionController : ControllerBase
    {
        private readonly IModulePermissionService _modulePermissionService;
        public ModulePermissionController(IModulePermissionService modulePermissionService)
        {
            _modulePermissionService = modulePermissionService;
        }
        [HttpGet]
        public async Task<APIResponse> GetAllModulePermissionAsync()
        {
            var apiResponse=await _modulePermissionService.GetAllModulePermissionAsync();
            return apiResponse;
        }
    }
}
