using Common.Identity.API.Common.Data.Data;
using Common.Identity.API.ModulePermissions.Modules;
using Common.Identity.API.Permissions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.ModulePermissions
{
    [Index(nameof(PermissionId),nameof(ModuleId),IsUnique =true)]
    [Table("module_permission",Schema ="users")]
    public class ModulePermission:BaseEntity
    {
        [Column("permission_id")]
        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }

        [Column("module_id")]
        public Guid ModuleId { get; set; }

        [ForeignKey(nameof(ModuleId))]
        //public virtual Modu Module { get; set; }
        public virtual Module Module { get; set; }
    }
}
