using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.RoleModulePermissions.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.RoleModulePermissions
{
    public class RoleModulePermissionRepository : GenericRepository<RoleModulePermission>,IRoleModulePermissionRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<RoleModulePermission> _dbSet;
        public RoleModulePermissionRepository(IdentityDataContext db):base(db)
        {
            _db = db;
            _dbSet=_db.Set<RoleModulePermission>(); 
        }
        public async Task<List<RoleModulePermission>> AddRoleModulesAsync(List<RoleModulePermission> roleModulePermissionList)
        {
            await _dbSet.AddRangeAsync(roleModulePermissionList);
            return roleModulePermissionList;
        }

        public async Task DeleteRoleModulePermissionByRoleId(Guid roleId)
        {
            var roleModulePermission=_dbSet.Where(x => x.RoleId == roleId).ToList();
            _db.RoleModulePermissions.RemoveRange(roleModulePermission);
        }

        public async Task<IQueryable<RoleModulePermission>> GetRoleModulePermissionsByRoleIdAsync(Guid roleId)
        {
            var result = _dbSet
                .Where(x => x.RoleId == roleId && x.IsDeleted == false)
                .Include(x => x.ModulePermission)
                .Include(x => x.ModulePermission.Module)
                .Include(x => x.ModulePermission.Permission);

            if (result == null)
            {
                throw new Exception($"RoleModulePermission with RoleId {roleId} not found");
            }
            return result;
        }
    }
}
