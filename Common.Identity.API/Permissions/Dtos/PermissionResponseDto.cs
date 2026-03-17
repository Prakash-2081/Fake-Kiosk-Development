using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Permissions.Dtos
{
    public class PermissionResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
