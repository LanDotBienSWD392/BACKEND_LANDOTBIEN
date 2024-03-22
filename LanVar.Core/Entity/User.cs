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
        public long permission_id { get; set; }

        

        public string identityCard { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public byte[]? image { get; set; }

        public string phone { get; set; }

        public DateTime dob { get; set; }

        public string address { get; set; }
        
        public string gender { get; set; }

        public DateTime registerDay { get; set; }

        public bool status { get; set; }

        [ForeignKey("permission_id")]
        public UserPermission userPermission { get; set; }

        
    }
}
