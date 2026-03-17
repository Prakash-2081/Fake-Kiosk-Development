using Common.Common.Response;
using Common.Identity.API.ModulePermissions.Modules.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Common.Identity.API.ModulePermissions.Modules
{
    [Route("api/module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService ?? throw new ArgumentNullException(nameof(moduleService));
        }
        [HttpGet]
        public Task<APIResponse> GetAllModuleAsync()
        {
            var apiResponse = _moduleService.GetAllModuleAsync();
            return apiResponse;
        }
    }
}
