using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.request;

    public class StaffDTORequest
    {
    [Required(ErrorMessage = "Permission is required")]
    public long Permission_id { get; set; }

    [RegularExpression("^0(0[1-9]|[1-8][0-9]|9[0-6])[0-3]([0-9][0-9])[0-9]{6}$", ErrorMessage = "CMND này éo có mày đùa tao à?")]
    [Required(ErrorMessage = "Số CMND là trường bắt buộc phải nhập.")]
    public string IdentityCard { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public string Image { get; set; }

    [RegularExpression("^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$", ErrorMessage = "Só điện thoại này fake!")]
    [Required(ErrorMessage = "Số điện thoại là trường bắt buộc phải nhập.")]
    public int Phone { get; set; }

    [Required(ErrorMessage = "Dob is required")]
    public DateTime Dob { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "RegisterDay is required")]
    public string RegisterDay { get; set; }
}

