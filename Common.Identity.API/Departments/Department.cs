using Common.Identity.API.Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Departments
{
    [Table("department",Schema ="organization")]
    public class Department:BaseEntity
    {
        [Column("department_name",TypeName ="VARCHAR(50)")]
        public string DepartmentName { get; set; }

        [Column("description", TypeName = "VARCHAR(250)")]
        public string Description { get; set; }
    }
}
