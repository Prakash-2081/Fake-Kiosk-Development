using Commmon.Data.Data;
using Common.Identity.API.Data;
using Common.Identity.API.Users.Contracts;

namespace Common.Identity.API.Users
{
    public class UserRepository:GenericRepository<User>,IUserRepository  
    {
        private readonly IdentityDataContext _db;
        public UserRepository(IdentityDataContext db):base(db)
        {
            _db = db;
        }
    }
}
