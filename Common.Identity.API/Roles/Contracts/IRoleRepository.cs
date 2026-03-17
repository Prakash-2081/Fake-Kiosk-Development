using Commmon.Data.Data.Contracts;

namespace Common.Identity.API.Roles.Contracts
{
    public interface IRoleRepository:IGenericRepository<Role>
    {
        Task<Role> FindByNameAsync(string name);
    }
}
