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
        
        public double price { get; set; }

        

        public bool status { get; set; }
    }
}
