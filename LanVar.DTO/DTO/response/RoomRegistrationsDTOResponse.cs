using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.response;

public class RoomRegistrationsDTOResponse
{
    public long id { get; set; }

    public long user_id { get; set; }

    public long auction_id { get; set; }

    public string status { get; set; }

    public DateTime register_time { get; set; }
}
