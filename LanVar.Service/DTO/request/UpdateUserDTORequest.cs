using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.DTO.request
{
    public class UpdateUserDTORequest
    {
        public string IdentityCard {  get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }   
        public string Email { get; set; }
    }
}
