using Common.Identity.API.RoleModulePermissions;

namespace Common.Identity.API.ModulePermissions.Dtos
{
    public static class ModulePermissionMapper
    {
        public static ModulePermissionResponseDto ToModulePermissionResponseDto(ModulePermission modulePermission)
        {
            var moduleName = modulePermission.Module?.Name ?? string.Empty;
            var permissionName = modulePermission.Permission?.Name ?? string.Empty;
            var moduleAlias = modulePermission.Module?.Alias ?? string.Empty;
            return new ModulePermissionResponseDto
            {
                 ModulePermissionId=modulePermission.Id,
                 ModuleId=modulePermission.ModuleId,
                 ModuleName=moduleName,
                 Alias=moduleAlias,
                 PermissionId=modulePermission.PermissionId,
                 PermissionName=permissionName
            };
        }

        public static ModulePermissionResponseDto ToModulePermissionResponseDto(RoleModulePermission roleModulePermission)
        {
            return new ModulePermissionResponseDto
            {
                ModuleId = roleModulePermission.ModulePermission.ModuleId,
                ModuleName = roleModulePermission.ModulePermission.Module?.Name ?? string.Empty,
                Alias = roleModulePermission.ModulePermission.Module?.Alias ?? string.Empty,
                PermissionId = roleModulePermission.ModulePermission.PermissionId,
                PermissionName = roleModulePermission.ModulePermission.Permission?.Name ?? string.Empty,
                ModulePermissionId = roleModulePermission.ModulePermissionId
            };
        }
    }
}
