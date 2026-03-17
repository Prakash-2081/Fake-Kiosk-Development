using Common.Identity.API.Common.Data.Data;
using Common.Identity.API.ModulePermissions;
using Common.Identity.API.Roles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.RoleModulePermissions
{
    [Index(nameof(RoleId),nameof(ModulePermissionId),IsUnique =true)]
    [Table("role_module_permission",Schema ="users")]
    public class RoleModulePermission:BaseEntity
    {
        [Column("role_id")]
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        [Column("module_permission_id")]
        public Guid ModulePermissionId { get; set; }

        [ForeignKey(nameof(ModulePermissionId))]
        public virtual ModulePermission ModulePermission { get; set; }

    }
}
