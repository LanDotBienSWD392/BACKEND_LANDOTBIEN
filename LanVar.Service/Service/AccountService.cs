using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.Service.DTO;
using LanVar.Service.DTO.request;
using LanVar.Service.Interface;

namespace LanVar.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        
        private readonly IMapper _mapper;

        public AccountService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserRegisterRequest userRegisterRequest)
        {
            var user = _mapper.Map<User>(userRegisterRequest);
            var addedUser = await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return addedUser;
        }

        

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateUser(long id, UpdateUserDTORequest updateUserDTORequest)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return null; // User not found
            }

            _mapper.Map(updateUserDTORequest, userToUpdate);

            _userRepository.Update(userToUpdate);
            await _userRepository.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<bool> DeactivateUser(long id)
        {
            var success = await _userRepository.DeactivateUser(id);
            return success;
        }

        public async Task<bool> ActivateUser(long id)
        {
            var success = await _userRepository.ActivateUser(id);
            return success;
        }

        public async Task<bool> DeleteUser(long id)
        {
            var success = await _userRepository.DeleteUser(id);
            return success;
        }
    }
}
