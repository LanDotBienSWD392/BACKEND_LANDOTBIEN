using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("UserPermission")]
    public class UserPermission
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
