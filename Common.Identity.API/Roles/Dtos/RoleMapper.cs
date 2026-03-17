using Common.Identity.API.ModulePermissions.Dtos;
using Common.Identity.API.RoleModulePermissions;

namespace Common.Identity.API.Roles.Dtos
{
    public static class RoleMapper
    {
        public static RoleResponseDto ToRoleResponseDto(Role role)
        {
            return new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive,
                IsDeleted = role.IsDeleted
            };
        }
        public static RoleResponseDto ToRoleResponseDto(Role role,List<RoleModulePermission> roleModulePermissions)
        {
            return new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive,
                IsDeleted = role.IsDeleted,
                ModulePermissions = roleModulePermissions.Select(ModulePermissionMapper.ToModulePermissionResponseDto).ToList()
            };
        }
        public static Role ToRole(RoleRequestDto roleDto)
        {
            return new Role
            {
                Name = roleDto.Name,
                Description = roleDto.Description,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTimeOffset.UtcNow
            };

        }
        public static Role ToUpdateRole(Role role,RoleRequestDto roleDto)
        {
            role.Name = roleDto.Name;
            role.Description = roleDto.Description;
            role.IsActive = roleDto.IsActive;
            role.ModifiedDate = DateTimeOffset.UtcNow;
            return role;
        }
    }
}
