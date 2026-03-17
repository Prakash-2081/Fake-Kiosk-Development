using Common.Common.Handlers;
using Common.Common.Response;
using Common.Identity.API.Data.Contracts;
using Common.Identity.API.ModulePermissions.Contracts;
using Common.Identity.API.ModulePermissions.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.API.ModulePermissions
{
    public class ModulePermissionService : IModulePermissionService
    {
        private readonly IUnitOfWork _db;
        public ModulePermissionService(IUnitOfWork db)
        {
            _db = db;
        }
        public async Task<APIResponse> GetAllModulePermissionAsync()
        {
            var data=await _db.ModulePermission.GetAllAsync();

            List<ModulePermissionResponseDto> responseData = data
                .Where(x=>x.IsDeleted ==false)
                .Include(x => x.Module)
                .Include(x => x.Permission)
                .Select(x => ModulePermissionMapper.ToModulePermissionResponseDto(x))
                .ToList();

            return ResponseHandler.GetSuccessResponse(responseData.OrderBy(x=>x.ModuleName));
        }
    }
}
