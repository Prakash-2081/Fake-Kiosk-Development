using Common.Common.Handlers;
using Common.Common.Response;
using Common.Identity.API.Data.Contracts;
using Common.Identity.API.Permissions.Contracts;
using Common.Identity.API.Permissions.Dtos;

namespace Common.Identity.API.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _db;
        public PermissionService(IUnitOfWork db)
        {
            _db = db;
        }
        public async Task<APIResponse> GetAllPermissionAsync()
        {
            var data=await _db.Permission.GetAllAsync();

            List<PermissionResponseDto> responseData = data
                .Where(x =>x.IsDeleted==false)
                .Select(x=>PermissionMapper.ToPermissionResponseDto(x))
                .ToList();

            return ResponseHandler.GetSuccessResponse(responseData);
        }
    }
}
