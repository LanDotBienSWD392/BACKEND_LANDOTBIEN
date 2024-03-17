using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity
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

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public bool Status { get; set; }
    }
}
