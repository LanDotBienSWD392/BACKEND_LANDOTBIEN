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
        public string packageName { get; set; }

        [Required]
        public string package_Description { get; set; }

        public DateTime startDay { get; set; }

        public DateTime endDay { get; set; }

        public bool status { get; set; }
    }
}
