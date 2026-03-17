using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.Departments.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Departments
{
    public class DepartmentRepository:GenericRepository<Department>,IDepartmentRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<Department> _dbSet;
        public DepartmentRepository(IdentityDataContext db):base(db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _dbSet = _db.Set<Department>();
        }

        public async Task<Department> FindByDepartmentNameAsync(string departmentName)
        {
            var entity= await _dbSet.FirstOrDefaultAsync(x => x.DepartmentName.ToLower().Trim() == departmentName.ToLower().Trim()
                && x.IsDeleted==false);
            return entity;
        }
    }
}
