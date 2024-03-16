using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        public long id { get; set; }

        [Required]
        public long Permission_id { get; set; }

        [Required]
        public long Package_id { get; set; }

        public string IdentityCard { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Image { get; set; }

        public int Phone { get; set; }

        public DateTime Dob { get; set; }

        public string Address { get; set; }

        
        public string Gender { get; set; }

        public DateTime RegisterDay { get; set; }

        public bool Status { get; set; }

        [ForeignKey("Permission_id")]
        public UserPermission UserPermission { get; set; }

        [ForeignKey("Package_id")]
        public Package Package { get; set; }
    }
}
