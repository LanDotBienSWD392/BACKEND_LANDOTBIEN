using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.DTO.request
{
    public class UpdateUserDTORequest
    {
        public required string IdentityCard {  get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required long Permission_id { get; set; }
        public required Boolean Status { get; set; }
        public required long Package_id {  get; set; }
    }
}
