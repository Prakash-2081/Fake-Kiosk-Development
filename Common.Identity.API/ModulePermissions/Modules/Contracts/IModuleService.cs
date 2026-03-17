using Common.Common.Response;

namespace Common.Identity.API.ModulePermissions.Modules.Contracts
{
    public interface IModuleService
    {
        Task<APIResponse> GetAllModuleAsync();
    }
}
