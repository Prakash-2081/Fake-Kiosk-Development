using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.Roles.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Roles
{
    public class RoleRepository:GenericRepository<Role>,IRoleRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<Role> _dbSet;
        public RoleRepository(IdentityDataContext db):base(db)
        {
            _db = db;
            _dbSet = _db.Set<Role>();
        }
        public async Task<Role> FindByNameAsync(string name)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Name == name && x.IsDeleted==false);
            return entity;
        }

    }
}
