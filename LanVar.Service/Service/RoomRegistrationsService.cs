using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanVar.Service.Service
{
    public class RoomRegistrationsService : IRoomRegistrationsService
    {
        private readonly IRoomRegistrationsRepository _roomRegistrationsRepository;
        private readonly IMapper _mapper;

        public RoomRegistrationsService(IRoomRegistrationsRepository roomRegistrationsRepository, IMapper mapper)
        {
            _roomRegistrationsRepository = roomRegistrationsRepository;
            _mapper = mapper;
        }

        public async Task<RoomRegistrationsDTOResponse> GetByIdAsync(long id)
        {
            var roomRegistrations = await _roomRegistrationsRepository.GetByIdAsync(id);
            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistrations);
        }

        public async Task<RoomRegistrationsDTOResponse> CreateAsync(RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            var roomRegistrations = _mapper.Map<RoomRegistrations>(roomRegistrationsDTO);
            roomRegistrations.register_time = DateTime.Now; // Assuming register time should be set upon creation
            await _roomRegistrationsRepository.AddAsync(roomRegistrations);
            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistrations);
        }

        public async Task<RoomRegistrationsDTOResponse> UpdateAsync(long id, RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            var existingRoomRegistrations = await _roomRegistrationsRepository.GetByIdAsync(id);
            if (existingRoomRegistrations == null)
            {
                throw new Exception("RoomRegistrations not found");
            }

            _mapper.Map(roomRegistrationsDTO, existingRoomRegistrations);
            await _roomRegistrationsRepository.UpdateAsync(existingRoomRegistrations);
            return _mapper.Map<RoomRegistrationsDTOResponse>(existingRoomRegistrations);
        }

        public async Task DeleteAsync(long id)
        {
            var existingRoomRegistrations = await _roomRegistrationsRepository.GetByIdAsync(id);
            if (existingRoomRegistrations == null)
            {
                throw new Exception("RoomRegistrations not found");
            }

            await _roomRegistrationsRepository.DeleteAsync(existingRoomRegistrations);
        }
    }
}
