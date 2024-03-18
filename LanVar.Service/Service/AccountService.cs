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
            user.permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.role.Equals("Manager"))).First().id;
            user.password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            user.status = false;
            user.registerDay = DateTime.Now.Date;
            user.image = null;
            user.package_id = 1;
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
            users.permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.role.Equals("Staff"))).First().id;
            users.password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            users.status = true;
            users.registerDay = DateTime.Now.Date;
            users.image = null;
            users.package_id = 1;
            await _userRepository.Add(users);
            return users;
        }
        private byte[] ReadImageDataFromFile(string imageName)
        {
            string imagePath = Path.Combine("Images", imageName); // Đường dẫn tương đối tới thư mục "Images"
            // Đọc dữ liệu của ảnh từ file
            byte[] imageData = File.ReadAllBytes(imagePath);
            return imageData;
        }

        private  byte[] GetDefaultImageForRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    return ReadImageDataFromFile("Admin.jpg"); // Thay đổi tên tập tin hình ảnh cho quản trị viên
                case "Manager":
                    return ReadImageDataFromFile("manager.jpg"); // Thay đổi tên tập tin hình ảnh cho quản lý viên
                case "Staff":
                    return ReadImageDataFromFile("Staff.jpg"); // Thay đổi tên tập tin hình ảnh cho nhân viên
                case "ProductOwner":
                    return ReadImageDataFromFile("ProductOwner.jpg"); // Thay đổi tên tập tin hình ảnh cho chủ sản phẩm
                case "Customer":
                    return ReadImageDataFromFile("Customer.jpg"); // Thay đổi tên tập tin hình ảnh cho khách hàng
                default:
                    return ReadImageDataFromFile("Guest.jpg"); // Trả về hình ảnh mặc định nếu không tìm thấy vai trò phù hợp
            }
        }


        public async Task<User> UpdateStaffUser(long id, UpdateUserDTORequest updateUserDTORequest)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return null; // User not found
            }
            if (userToUpdate.permission_id == 1 || userToUpdate.permission_id == 2)
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
            if (userToDelete.permission_id == 1 || userToDelete.permission_id == 2)
            {
                throw new Exception("Không được phép xóa người dùng với quyền này.");
            }

            // Tiến hành xóa chỉ khi không có vấn đề với quyền
            var success = await _userRepository.DeleteUser(id);
            return success;
        }
    }
}
