namespace Common.Identity.API.Permissions.Dtos
{
    public static class PermissionMapper
    {
        public static PermissionResponseDto ToPermissionResponseDto(this Permission permission)
        {
            return new PermissionResponseDto
            {
                 Id=permission.Id,
                 Name=permission.Name,
                 Description=permission.Description,
                 IsActive=permission.IsActive,
                 IsDeleted=permission.IsDeleted
            };
        }
    }
}
