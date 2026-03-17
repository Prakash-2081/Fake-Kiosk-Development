using Common.Identity.API.ModulePermissions.Dtos;

namespace Common.Identity.API.Roles.Dtos
{
    public class RoleResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<ModulePermissionResponseDto> ModulePermissions { get; set; }
    }
}
