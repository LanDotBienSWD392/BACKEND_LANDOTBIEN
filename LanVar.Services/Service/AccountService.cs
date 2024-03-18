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

using LanVar.Services.Interface;
using Tools.Tools;

namespace LanVar.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IGenericRepository<User> _genericUserRepository;
        private readonly IPackageService _packageService;
        private readonly IMapper _mapper;

        public AccountService(IUserRepository userRepository, IMapper mapper, IUserPermissionRepository userPermissionRepository,IGenericRepository<User> genericUserRepository)
        {
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
            _mapper = mapper;
            _genericUserRepository = genericUserRepository;
        }

        public async Task<User> CreateUser(CreateAccountDTORequest createAccountDTORequest)
        {
            IEnumerable<User> checkEmail =
                await _userRepository.GetByFilterAsync(x => x.email.Equals(createAccountDTORequest.Email));
            IEnumerable<User> checkUsername =
                await _userRepository.GetByFilterAsync(x => x.username.Equals(createAccountDTORequest.Username));
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
            user.identityCard = "123123123123";
            user.permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.role.Equals("Manager"))).First().id;
            user.password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            user.status = false;
            user.registerDay = DateTime.Now.Date;
            user.image = "";
            user.package_id = 1;
            user.gender = "Gay";
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
                await _userRepository.GetByFilterAsync(x => x.email.Equals(createAccountDTORequest.Email));
            IEnumerable<User> checkUsername =
                await _userRepository.GetByFilterAsync(x => x.username.Equals(createAccountDTORequest.Username));
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
            users.identityCard = "12312312333123";
            users.permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.role.Equals("Staff"))).First().id;
            users.password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            users.status = true;
            users.registerDay = DateTime.Now.Date;
            users.image = "";
            users.package_id = 1;
            users.gender = "Gay";
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
            if (userToUpdate.permission_id == 1 || userToUpdate.permission_id == 2 || userToUpdate.permission_id == 6 || userToUpdate.permission_id == 7)
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
            if (userToDelete.permission_id == 1 || userToDelete.permission_id == 2 || userToDelete.permission_id == 6 || userToDelete.permission_id == 7)
            {
                throw new Exception("Không được phép xóa người dùng với quyền này.");
            }

            // Tiến hành xóa chỉ khi không có vấn đề với quyền
            var success = await _userRepository.DeleteUser(id);
            return success;
        }

        public async Task<User> PurchasePackage(long userId)
        {
            try
            {
                var userToUpdate = await _userRepository.GetByIdAsync(userId);
                if (userToUpdate == null)
                {
                    throw new Exception("User not found");
                }
                //Thêm func check đã thanh toán ch

                // Cập nhật package_id cho user
                userToUpdate.package_id = 2;

               return await _genericUserRepository.Update(userToUpdate);
               

                
            }
            catch (Exception ex)
            {
                throw new Exception("Thanh toán không thành công");
            }
        }
    }
}
