using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.request;

public class EnterAuctionDTORequest
{
    [Required(ErrorMessage = "id is required")]
    public long id { get; set; }

    [Required(ErrorMessage = "User is required")]
    public long user_id { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
