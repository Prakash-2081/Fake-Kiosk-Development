using Common.Identity.API.Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Common.Models
{
    public class CommonPermission:BaseEntity
    {
        [Column("name",TypeName ="VARCHAR(50)")]
        public string Name { get; set; }
        [Column("alias",TypeName ="VARCHAR(50)")]
        public string Alias { get; set; }
        [Column("description",TypeName ="VARCHAR(255)")]
        public string Description { get; set; }
    }
}
