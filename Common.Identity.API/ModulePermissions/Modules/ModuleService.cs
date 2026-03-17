using Common.Common.Handlers;
using Common.Common.Response;
using Common.Identity.API.Data.Contracts;
using Common.Identity.API.ModulePermissions.Modules.Contracts;
using Common.Identity.API.ModulePermissions.Modules.Dtos;

namespace Common.Identity.API.ModulePermissions.Modules
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _db;

        public ModuleService(IUnitOfWork db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<APIResponse> GetAllModuleAsync()
        {
            var data = await _db.Module.GetAllAsync();

            List<ModuleResponseDto> responseData = data
                .Where(x => x.IsDeleted == false)
                .Select(x => ModuleMapper.ToModuleResponseDto(x))
                .ToList();

            return ResponseHandler.GetSuccessResponse(responseData);
        }
    }
}
