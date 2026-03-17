using Common.Common.Response;

namespace Common.Identity.API.Permissions.Contracts
{
    public interface IPermissionService
    {
        Task<APIResponse> GetAllPermissionAsync();
    }
}
