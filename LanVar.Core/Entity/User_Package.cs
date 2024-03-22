using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanVar.Core.Entity;
public enum PackageStatus
{
    Pending,
    Active,
    Expired,
    Canceled
}
public class User_Package
{
    [Key]
    public long id { get; set; }
    
    [Required]
    public long package_id { get; set; }
    
    [Required]
    public long user_id { get; set; }
    
    public DateTime startDay { get; set; }

    public DateTime endDay { get; set; }
    
    public double price { get; set; }
    
    public PackageStatus status { get; set; }
    
    [ForeignKey("package_id")]
    public Package package { get; set; }
    
    [ForeignKey("user_id")]
    public User user { get; set; }
}