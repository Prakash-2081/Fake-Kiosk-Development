using Commmon.Data.Data.Contracts;

namespace Common.Identity.API.RoleModulePermissions.Contracts
{
    public interface IRoleModulePermissionRepository:IGenericRepository<RoleModulePermission>
    {
        Task<List<RoleModulePermission>> AddRoleModulesAsync(List<RoleModulePermission> roleModulePermissionList);
        Task  DeleteRoleModulePermissionByRoleId(Guid roleId);
        Task<IQueryable<RoleModulePermission>> GetRoleModulePermissionsByRoleIdAsync(Guid roleId);
    }
}
