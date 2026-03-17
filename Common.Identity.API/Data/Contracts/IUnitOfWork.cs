using Common.Identity.API.Departments.Contracts;
using Common.Identity.API.ModulePermissions.Contracts;
using Common.Identity.API.ModulePermissions.Modules.Contracts;
using Common.Identity.API.Permissions.Contracts;
using Common.Identity.API.RoleModulePermissions.Contracts;
using Common.Identity.API.Roles.Contracts;

namespace Common.Identity.API.Data.Contracts
{
    public interface IUnitOfWork:IDisposable
    {
        IPermissionRepository Permission{ get; }
        IModuleRepository Module { get; }
        IModulePermissionRepository ModulePermission { get; }
        IRoleRepository Role { get; }
        IRoleModulePermissionRepository RoleModulePermission { get; }

        IDepartmentRepository Department { get; }
        Task<string> SaveAsync();
        Task BeginTransactionAysnc();
        Task RollBackTransactionAsync();
        Task<string> CommitTransactionAsync();
    }
}
