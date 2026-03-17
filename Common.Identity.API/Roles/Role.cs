using Common.Identity.API.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Roles
{
    [Table("role",Schema ="users")]
    public class Role:CommonRole
    {
       
    }
}
