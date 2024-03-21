using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.Service.DTO.request
{
    public class UpdateUserDTORequest
    {
        [RegularExpression("^0(0[1-9]|[1-8][0-9]|9[0-6])[0-3]([0-9][0-9])[0-9]{6}$", ErrorMessage = "CMND này éo có mày đùa tao à?")]
        [Required(ErrorMessage = "Số CMND là trường bắt buộc phải nhập.")]
        public required string IdentityCard {  get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 8)]
        public required string Name { get; set; }
        [RegularExpression("^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$", ErrorMessage = "Só điện thoại này fake!")]
        [Required(ErrorMessage = "Số điện thoại là trường bắt buộc phải nhập.")]
        public required string phone { get; set; }
        [CustomDataValidation.EmailValidation]
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required long Permission_id { get; set; }
        public required Boolean Status { get; set; }
    }
}
