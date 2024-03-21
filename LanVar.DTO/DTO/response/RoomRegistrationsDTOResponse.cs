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

    public UserDTOResponse User { get; set; } // Thêm thông tin người dùng

    public AuctionDTOResponse Auction { get; set; } // Thêm thông tin phiên đấu giá

    public string status { get; set; }

    public DateTime register_time { get; set; }
}
