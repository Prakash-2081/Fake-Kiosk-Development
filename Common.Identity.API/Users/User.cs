using Common.Identity.API.Common.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Identity.API.Users
{
    [Table("users", Schema = "users")]
    public class User : BaseEntity
    {
        [Column("is_ad_user")]
        public bool IsADUser { get; set; } = false;

        [Column("user_name", TypeName = "VARCHAR(50)")]
        public string UserName { get; set; }

        [Column("salt", TypeName = "VARCHAR(255)")]
        public string? Salt { get; set; }

        [Column("user_password",TypeName ="VARCHAR(255)")]
        public string? UserPassword { get; set; }

        [Column("email",TypeName ="VARCHAR(255)")]
        public string Email { get; set; }

        [Column("phone_number",TypeName ="VARCHAR(50)")]
        public string? PhoneNumber { get; set; }

        [Column("lock_out_enabled")]
        public bool LockoutEnabled { get; set; } = false;

        [Column("lock_out_count",TypeName ="INT")]
        public int LockoutCount { get;set; } = 0;

        [Column("is_email_confirmed")]
        public bool IsEmailConfirmed { get; set; } = false;

        [Column("is_locked")]
        public bool IsLocked { get; set; } = false;

    }
}
