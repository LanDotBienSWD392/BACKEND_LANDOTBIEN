using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.DTO.DTO.request
{
    public class CreateAccountDTORequest
    {
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public required string Name { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public required string Username { get; set; }
        [CustomDataValidation.EmailValidation]
        public required string Email { get; set; }
        [CustomDataValidation.PasswordValidation]
        public required string Password { get; set; }
        [CustomDataValidation.AgeValidation(18, 65)]
        public DateTime RegisterDay { get; set; }
        public string Image { get; set; }
        [StringLength(maximumLength: 99, MinimumLength = 4)]
        public required string Address { get; set; }
        public bool Status { get; set; }
        public int Package_id { get; set; }
    }
}
