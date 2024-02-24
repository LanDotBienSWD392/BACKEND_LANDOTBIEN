using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
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
