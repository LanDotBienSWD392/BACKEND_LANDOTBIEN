using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Repository.IRepository;
using LanVar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Tools;

namespace LanVar.Service.Service
{
    public class RoomRegistrationsService : IRoomRegistrationsService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IRoomRegistrationsRepository _roomRegistrationsRepository;
        private readonly IMapper _mapper;

        public RoomRegistrationsService(IAuctionRepository auctionRepository, IRoomRegistrationsRepository roomRegistrationsRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _roomRegistrationsRepository = roomRegistrationsRepository;
            _mapper = mapper;
        }

        public async Task<RoomRegistrationsDTOResponse> GetByIdAsync(long id)
        {
            var roomRegistrations = await _roomRegistrationsRepository.GetByAuctionIdAsync(id);

            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistrations);
        }

        public async Task<RoomRegistrationsDTOResponse> CreateAsync(RoomRegistrationsDTORequest roomRegistrationsDTO)
        {
            var auction = await _auctionRepository.GetByIdAsync(roomRegistrationsDTO.auction_id);

            // Check if the auction status is ACTIVE
            if (auction == null || auction.status != AuctionStatus.ACTIVE)
            {
                throw new Exception("Auction is not active.");
            }

            // Check if user already registered in the auction
            var existingRegistration = await _roomRegistrationsRepository.GetByFilterAsync(rr => rr.auction_id == roomRegistrationsDTO.auction_id && rr.user_id == roomRegistrationsDTO.user_id);
            if (existingRegistration.Any())
            {
                throw new Exception("User has already registered in this auction.");
            }

            roomRegistrationsDTO.status = RegisterStatus.WAITING.ToString();
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

        public async Task<List<RoomRegistrationsDTOResponse>> GetByAuctionIdAsync(long auctionId)
        {
            var roomRegistrationsList = await _roomRegistrationsRepository.GetByAuctionIdAsync(auctionId);
            return _mapper.Map<List<RoomRegistrationsDTOResponse>>(roomRegistrationsList);
        }

        public async Task<RoomRegistrationsDTOResponse> AcceptUser(long roomRegistrationId)
        {
            var roomRegistration = await _roomRegistrationsRepository.GetByIdAsync(roomRegistrationId);
            if (roomRegistration == null)
            {
                throw new Exception("RoomRegistrations not found");
            }

            // Perform your logic to accept the user here.
            // For example, you may change the status of the room registration to "ACTIVE".
            roomRegistration.status = RegisterStatus.ACTIVE;

            // Save the changes to the database.
            await _roomRegistrationsRepository.UpdateAsync(roomRegistration);

            // Map the updated room registration to DTO response and return it.
            return _mapper.Map<RoomRegistrationsDTOResponse>(roomRegistration);
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
