using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.ModulePermissions.Modules.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.ModulePermissions.Modules
{
    public class ModuleRepository:GenericRepository<Module>,IModuleRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<Module> _dbSet;
        public ModuleRepository(IdentityDataContext db):base(db)
        {
            _db= db;
            _dbSet = _db.Set<Module>();
        }
    }
}
