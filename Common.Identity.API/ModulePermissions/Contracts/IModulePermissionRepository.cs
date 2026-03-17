using Commmon.Data.Data.Contracts;

namespace Common.Identity.API.ModulePermissions.Contracts
{
    public interface IModulePermissionRepository:IGenericRepository<ModulePermission>
    {
        Task<IQueryable<ModulePermission>> GetModulePermissionsListByIdsAsync(List<string> ids);
    }
}
