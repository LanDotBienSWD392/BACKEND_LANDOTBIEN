using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.request;

public class RoomRegistrationsDTORequest
{
    /*public long id { get; set; }*/

    [Required(ErrorMessage = "User is required")]
    public long user_id { get; set; }

    [Required(ErrorMessage = "Auction is required")]
    public long auction_id { get; set; }

    public string status { get; set; }

    public DateTime register_time { get; set; }
}
