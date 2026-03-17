using Common.Common.Response;
using Common.Identity.API.Roles.Dtos;

namespace Common.Identity.API.Roles.Contracts
{
    public interface IRoleService
    {
        Task<APIResponse> AddRoleAsync(RoleRequestDto requestDto);
        Task<APIResponse> UpdateRoleAsync(Guid id, RoleRequestDto requestDto);
        Task<APIResponse> DeleteRoleAsync(Guid id);
        Task <APIResponse> GetAllRoleAsync();
        Task<APIResponse> GetRoleByIdAsync(Guid id);
    }
}
