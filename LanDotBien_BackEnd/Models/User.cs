using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
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

        [Required]
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

        [Required]
        public int Phone { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string RegisterDay { get; set; }

        [Required]
        public bool Status { get; set; }

        [ForeignKey("Permission_id")]
        public UserPermission UserPermission { get; set; }

        [ForeignKey("Package_id")]
        public Package Package { get; set; }
    }
}
