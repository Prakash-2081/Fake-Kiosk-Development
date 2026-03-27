using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Common.Models.Library
{
    public class CommonLibrary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name",TypeName ="VARCHAR(50)")]
        public string Name { get; set; }
    }
}
