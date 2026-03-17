namespace Common.Identity.API.RoleModulePermissions.Dtos
{
    public static class RoleModulePermissionMapper
    {
        public static RoleModulePermission ToRoleModulePermission(Guid roleId,Guid modulePermissionId)
        {
            return new RoleModulePermission
            {
                RoleId = roleId,
                ModulePermissionId = modulePermissionId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow,
            };
        }
    }
}
