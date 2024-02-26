using System.ComponentModel.DataAnnotations;
using Tools.Tools;
namespace LanVar.Service.DTO;

public class UserRegisterRequest
{
    [StringLength(maximumLength:40, MinimumLength = 8)]
    public required string Name { get; set; }
    [StringLength(maximumLength:40, MinimumLength = 8)]
    public required string Username { get; set; }
    [CustomDataValidation.EmailValidation]
    public required string Email { get; set; }
    [CustomDataValidation.PasswordValidation]
    public required string Password { get; set; }
    [CustomDataValidation.AgeValidation(18,65)]
    public DateTime Dob { get; set; }
   // public string FormattedDob => Dob.Date.ToString("yyyy-MM-dd");
    public string Gender { get; set; }
    [CustomDataValidation.IdentityValidation]
    public required string IdentityCard { get; set; }
    [CustomDataValidation.PhoneNumberValidation]
    public required string Phone { get; set; }
    public string RegisterDay { get; set; }
    public string Image { get; set; }
    [StringLength(maximumLength:99, MinimumLength = 4)]
    public required string Address { get; set; }
    public bool Status { get; set; }
    public int Package_id { get; set; }

}