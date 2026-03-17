using Common.Common.Handlers;
using Common.Common.Response;
using Common.Identity.API.Data.Contracts;
using Common.Identity.API.ModulePermissions;
using Common.Identity.API.RoleModulePermissions;
using Common.Identity.API.RoleModulePermissions.Dtos;
using Common.Identity.API.Roles.Contracts;
using Common.Identity.API.Roles.Dtos;

namespace Common.Identity.API.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _db;

        public RoleService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<APIResponse> AddRoleAsync(RoleRequestDto requestDto)
        {
            var validationResult = requestDto.Validate();
            if (!validationResult.IsValid)
            {
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }
            var checkRoleExist = await _db.Role.FindByNameAsync(requestDto.Name);

            if (checkRoleExist !=null)
            {
                throw new Exception($"Role already exists with name: {requestDto.Name} and exit process.");
            }

            Role role=RoleMapper.ToRole(requestDto);
            role = await _db.Role.AddAsync(role);

            List<ModulePermission> modulePermissions =  _db.ModulePermission.GetModulePermissionsListByIdsAsync(requestDto.ModulePermissionIds).Result.ToList();

            List<RoleModulePermission> roleModulePermissions = modulePermissions
                .Select(x => RoleModulePermissionMapper.ToRoleModulePermission(role.Id, x.Id))
                .ToList();

            roleModulePermissions = await _db.RoleModulePermission.AddRoleModulesAsync(roleModulePermissions);

            string result=await _db.SaveAsync();

            var responseDto = RoleMapper.ToRoleResponseDto(role);
            return ResponseHandler.GetSuccessResponse(responseDto,result);
        }

        public async Task<APIResponse> DeleteRoleAsync(Guid id)
        {
            Role role = await _db.Role.GetByIdAsync(id);
            if (role == null) 
            {
                throw new Exception($"Role with id {id} not found");
            }
            role.IsDeleted = true;
            role= _db.Role.UpdateAsync(role);
            string result=await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(RoleMapper.ToRoleResponseDto(role),result);

        }

        public async Task<APIResponse> GetAllRoleAsync()
        {
            var entities = await _db.Role.GetAllAsync();

            //List<RoleResponseDto> responseDtos=entity
            //    .Select(x=>RoleMapper.ToRoleResponseDto(x))
            //    .ToList();
            var data = entities.Where(x => x.IsDeleted == false);

            List<RoleResponseDto> responseDtos = new List<RoleResponseDto>();

            foreach (var entity in data)
            {
                var item=RoleMapper.ToRoleResponseDto(entity);
                responseDtos.Add(item);
            }

            return ResponseHandler.GetSuccessResponse(responseDtos);
        }

        public async Task<APIResponse> GetRoleByIdAsync(Guid id)
        {
            Role role=await _db.Role.GetByIdAsync(id);

            List<RoleModulePermission> roleModulePermissionList = _db.RoleModulePermission
                .GetRoleModulePermissionsByRoleIdAsync(role.Id).Result.ToList();

            return ResponseHandler.GetSuccessResponse(RoleMapper.ToRoleResponseDto(role,roleModulePermissionList));

        }

        public async Task<APIResponse> UpdateRoleAsync(Guid id, RoleRequestDto requestDto)
        {
            var validationResult=requestDto.Validate();
            if (!validationResult.IsValid)
            {
                return ResponseHandler.GetValidationErrorResponse(validationResult);
            }
            Role role=await _db.Role.GetByIdAsync(id);

            if (role ==null)
            {
                throw new Exception($"Role with RoleId {id} doesnot exist");
            }

            List<ModulePermission> modulePermissions =
                _db.ModulePermission.GetModulePermissionsListByIdsAsync(requestDto.ModulePermissionIds).Result.ToList();

            if(role.Name.ToUpper() != requestDto.Name.ToUpper())
            {
                var checkRole = _db.Role.FindByNameAsync(requestDto.Name).Result;
                if (checkRole != null)
                {
                    throw new Exception($"Role name already exist");
                }
            }
            role=RoleMapper.ToUpdateRole(role,requestDto);

            role = _db.Role.UpdateAsync(role);

            List<RoleModulePermission> roleModulePermissions = modulePermissions
                .Select(x => RoleModulePermissionMapper.ToRoleModulePermission(role.Id, x.Id))
                .ToList();

            _db.RoleModulePermission.DeleteRoleModulePermissionByRoleId(role.Id);

            roleModulePermissions = await _db.RoleModulePermission.AddRoleModulesAsync(roleModulePermissions);

            var roleModulePermissionList = _db.RoleModulePermission.GetRoleModulePermissionsByRoleIdAsync(role.Id);
            
            roleModulePermissions = roleModulePermissionList.Result.ToList();


            var result=await _db.SaveAsync();

            return ResponseHandler.GetSuccessResponse(RoleMapper.ToRoleResponseDto(role,roleModulePermissions));
        }
    }
}
