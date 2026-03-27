using Common.Identity.API.Common.Libraries.Contracts;
using Common.Identity.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.Common.Libraries
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly IdentityDataContext _db;
        internal DbSet<Library> _dbSet;
        public LibraryRepository(IdentityDataContext db)
        {
            _db = db;
            _dbSet = _db.Set<Library>();
        }

        public async Task<Library> AddAsync(Library library)
        {
            await _dbSet.AddAsync(library);
            return library; 
        }

        public async Task<Library> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x=>x.Id==id);
            return entity;
        }

        public async Task<Library> UpdateAsync(Library library)
        {
            _db.Attach(library);
            _db.Entry(library).State = EntityState.Modified;
            return library;
        }
    }
}
