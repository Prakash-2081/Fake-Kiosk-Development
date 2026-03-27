using Common.Common.Models.Library;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Common.Libraries
{
    [Table("library",Schema ="dms")]
    public class Library:CommonLibrary
    {
    }
}
