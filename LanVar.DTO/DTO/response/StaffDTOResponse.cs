using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.response;

public class StaffDTOResponse
{
    public long Permission_id { get; set; }

    public string IdentityCard { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Image { get; set; }

    public int Phone { get; set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public string Gender { get; set; }

    public string RegisterDay { get; set; }
}
