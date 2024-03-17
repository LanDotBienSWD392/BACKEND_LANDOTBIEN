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

    [Required(ErrorMessage = "IdentityCard Name is required")]
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

    [Required(ErrorMessage = "Phone is required")]
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

