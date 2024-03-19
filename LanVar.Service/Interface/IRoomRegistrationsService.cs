using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Interface
{
    public interface IRoomRegistrationsService
    {
        Task<RoomRegistrationsDTOResponse> GetByIdAsync(long id);
        Task<RoomRegistrationsDTOResponse> CreateAsync(RoomRegistrationsDTORequest roomRegistrationsDTO);
        Task<RoomRegistrationsDTOResponse> UpdateAsync(long id, RoomRegistrationsDTORequest roomRegistrationsDTO);
        Task DeleteAsync(long id);
    }
}
