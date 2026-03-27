using Commmon.Data.Data.Contracts;

namespace Common.Identity.API.Common.Libraries.Contracts
{
    public interface ILibraryRepository
    {
        Task<Library> AddAsync(Library library);
        Task<Library> GetByIdAsync(Guid id);
        Task<Library> UpdateAsync(Library library);
    }
}
