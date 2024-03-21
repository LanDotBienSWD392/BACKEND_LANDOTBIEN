using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.DTO.DTO.response;

public class UserDTOResponse
{
    public long permission_id { get; set; }

    public string identityCard { get; set; }

    public string name { get; set; }

    public long package_id { get; set; }

    public string email { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public string image { get; set; }

    public int phone { get; set; }

    public DateTime dob { get; set; }

    public string address { get; set; }

    public string gender { get; set; }

    public string registerDay { get; set; }
}
