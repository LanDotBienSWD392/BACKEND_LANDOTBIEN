using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACKEND.Models
{
    [Table("Package")]
    public class Package
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string PackageName { get; set; }

        [Required]
        public string Package_Description { get; set; }

        [Required]
        public DateTime StartDay { get; set; }

        [Required]
        public DateTime EndDay { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
