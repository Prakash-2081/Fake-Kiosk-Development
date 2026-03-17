using Common.Identity.API.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Permissions
{
    [Table("permission", Schema = "users")]
    public class Permission:CommonPermission
    {
    }
}
