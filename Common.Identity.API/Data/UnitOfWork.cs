using Common.Identity.API.Data.Contracts;
using Common.Identity.API.Departments;
using Common.Identity.API.Departments.Contracts;
using Common.Identity.API.ModulePermissions;
using Common.Identity.API.ModulePermissions.Contracts;
using Common.Identity.API.ModulePermissions.Modules;
using Common.Identity.API.ModulePermissions.Modules.Contracts;
using Common.Identity.API.Permissions;
using Common.Identity.API.Permissions.Contracts;
using Common.Identity.API.RoleModulePermissions;
using Common.Identity.API.RoleModulePermissions.Contracts;
using Common.Identity.API.Roles;
using Common.Identity.API.Roles.Contracts;

namespace Common.Identity.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDataContext _db;
        public UnitOfWork(IdentityDataContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            Permission = new PermissionRepository(db);
            Module = new ModuleRepository(db);
            ModulePermission= new ModulePermissionRepository(db);
            Role=new RoleRepository(db);
            RoleModulePermission = new RoleModulePermissionRepository(db);
            Department=new DepartmentRepository(db);
        }
        public IPermissionRepository Permission { get; private set; }
        public IModuleRepository Module { get; private set; }
        public IModulePermissionRepository ModulePermission { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IRoleModulePermissionRepository RoleModulePermission { get; private set; }
        public IDepartmentRepository Department { get; private set; }

        public Task BeginTransactionAysnc()
        {
            throw new NotImplementedException();
        }

        public Task<string> CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Task RollBackTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveAsync()
        {
            try
            {
                int result = await _db.SaveChangesAsync();
                if(result > 0)
                {
                    return "Save Successful";
                }
                else if (result == 0)
                {
                    return "No changes were saved";
                }
                else
                {
                    return "Save Operation Encountered an Error";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
