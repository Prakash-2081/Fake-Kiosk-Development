using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.ModulePermissions.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Common.Identity.API.ModulePermissions
{
    public class ModulePermissionRepository:GenericRepository<ModulePermission>,IModulePermissionRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<ModulePermission> _dbSet;
        public ModulePermissionRepository(IdentityDataContext db):base(db)
        {
            _db = db;
            _dbSet = _db.Set<ModulePermission>();
        } 

        public async Task<IQueryable<ModulePermission>> GetModulePermissionsListByIdsAsync(List<string> ids)
        {
            List<Guid> idsList = ids
                .Select(x => Guid.TryParse(x, out Guid guid) ? guid : Guid.Empty)
                .Where(x => x != Guid.Empty)
                .ToList();

            IQueryable<ModulePermission> resultData = _dbSet.Where(x=>idsList.Contains(x.Id));
            return resultData;
            
        }
    }
}
