using Common.Identity.API.Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Common.Models
{
    public class CommonRole:BaseEntity
    {
        [Column("name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Column("description", TypeName = "VARCHAR(250)")]
        public string Description { get; set; }
    }
}
