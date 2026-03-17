using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.Permissions.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Permissions
{
    public class PermissionRepository:GenericRepository<Permission>,IPermissionRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<Permission> _dbSet;
        public PermissionRepository(IdentityDataContext db):base(db)
        {
            _db= db;
            _dbSet = _db.Set<Permission>();
        }
    }
}
