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
using Tools.Tools;

namespace LanVar.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        
        private readonly IMapper _mapper;

        public AccountService(IUserRepository userRepository, IMapper mapper, IUserPermissionRepository userPermissionRepository)
        {
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(CreateAccountDTORequest createAccountDTORequest)
        {
            IEnumerable<User> checkEmail =
                await _userRepository.GetByFilterAsync(x => x.Email.Equals(createAccountDTORequest.Email));
            IEnumerable<User> checkUsername =
                await _userRepository.GetByFilterAsync(x => x.Username.Equals(createAccountDTORequest.Username));
            if (checkEmail.Count() != 0)
            {
                throw new InvalidDataException($"Email is exist");
            }

            if (checkUsername.Count() != 0)
            {
                throw new InvalidDataException($"Username is exist");
            }
            var user = _mapper.Map<User>(createAccountDTORequest);

            // Set status = false when initializing user
            user.IdentityCard = "123123123123";
            user.Permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.Role.Equals("Manager"))).First().id;
            user.Password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            user.Status = false;
            user.RegisterDay = DateTime.Now.Date;
            user.Image = "";
            user.Package_id = 1;
            user.Gender = "Gay";
            await _userRepository.Add(user);
            return user;
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

        public async Task<IEnumerable<User>> GetAllStaffUsers()
        {
            return await _userRepository.GetAllStaffUsers();
        }

        public async Task<User> CreateStaffUser(CreateAccountDTORequest createAccountDTORequest)
        {
            IEnumerable<User> checkEmail =
                await _userRepository.GetByFilterAsync(x => x.Email.Equals(createAccountDTORequest.Email));
            IEnumerable<User> checkUsername =
                await _userRepository.GetByFilterAsync(x => x.Username.Equals(createAccountDTORequest.Username));
            if (checkEmail.Count() != 0)
            {
                throw new InvalidDataException($"Email is exist");
            }

            if (checkUsername.Count() != 0)
            {
                throw new InvalidDataException($"Username is exist");
            }
            var users = _mapper.Map<User>(createAccountDTORequest);

            // Set status = false when initializing user
            users.IdentityCard = "12312312333123";
            users.Permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.Role.Equals("Staff"))).First().id;
            users.Password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            users.Status = true;
            users.RegisterDay = DateTime.Now.Date;
            users.Image = "";
            users.Package_id = 1;
            users.Gender = "Gay";
            await _userRepository.Add(users);
            return users;
        }

        public async Task<User> UpdateStaffUser(long id, UpdateUserDTORequest updateUserDTORequest)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return null; // User not found
            }
            if (userToUpdate.Permission_id == 1 || userToUpdate.Permission_id == 2 || userToUpdate.Permission_id == 6 || userToUpdate.Permission_id == 7)
            {
                throw new Exception("Không được phép cập nhật người dùng với quyền này.");
            }
            // Tiến hành cập nhật chỉ khi không có vấn đề với quyền
            _mapper.Map(updateUserDTORequest, userToUpdate);
            _userRepository.Update(userToUpdate);
            await _userRepository.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<bool> DeleteStaffUser(long id)
        {
            var userToDelete = await _userRepository.GetByIdAsync(id);
            if (userToDelete == null)
            {
                return false; // Không tìm thấy người dùng để xóa
            }

            // Kiểm tra nếu permission_id = 1, không cho phép xóa
            if (userToDelete.Permission_id == 1 || userToDelete.Permission_id == 2 || userToDelete.Permission_id == 6 || userToDelete.Permission_id == 7)
            {
                throw new Exception("Không được phép xóa người dùng với quyền này.");
            }

            // Tiến hành xóa chỉ khi không có vấn đề với quyền
            var success = await _userRepository.DeleteUser(id);
            return success;
        }
    }
}
