using Common.Common.Response;

namespace Common.Identity.API.ModulePermissions.Contracts
{
    public interface IModulePermissionService
    {
        Task<APIResponse> GetAllModulePermissionAsync();
    }
}
