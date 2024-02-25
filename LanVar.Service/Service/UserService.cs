using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Service.DTO;
using LanVar.Service.DTO.response;
using LanVar.Service.Interface;
using Microsoft.Extensions.Configuration;
using Tools.Tools;

namespace LanVar.Service.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserPermissionRepository _userPermissionRepository;
		private readonly IGenericRepository<User> _genericRepository;
		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		public UserService(
			IUserRepository userRepository,
			IMapper mapper,
			IGenericRepository<User> genericRepository,
			IConfiguration configuration,
			IUserPermissionRepository userPermissionRepository
			)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_configuration = configuration;
			_genericRepository = genericRepository;
			_userPermissionRepository = userPermissionRepository;
		}

		public async Task<User> Register(UserRegisterRequest userRegisterRequest)
		{
			IEnumerable<User> checkEmail =
				await _userRepository.GetByFilterAsync(x => x.Email.Equals(userRegisterRequest.Email));
			IEnumerable<User> checkUsername =
				await _userRepository.GetByFilterAsync(x => x.Username.Equals(userRegisterRequest.Username));
			if (checkEmail.Count() != 0)
			{
				throw new InvalidDataException($"Email is exist");
			}

			if (checkUsername.Count() != 0)
			{
				throw new InvalidDataException($"Username is exist");
			}

			var user = _mapper.Map<User>(userRegisterRequest);
			user.Permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.Role.Equals("Customer"))).First().id;
			user.Password = EncryptPassword.Encrypt(userRegisterRequest.Password);
			user.Status = true;
			user.RegisterDay = DateTime.Now.Date.ToString();
			user.Gender = userRegisterRequest.Gender;
			user.Image = "nguyen rua anh nao de image laf required";
			user.Package_id = 1;
			
			_userRepository.Add(user);
			return user;
		}

		public async Task<(string, LoginDTOResponse)> Login(LoginDTORequest loginDtoRequest)
		{
			string hashedPass = EncryptPassword.Encrypt(loginDtoRequest.Password);
			IEnumerable<User> check = await _userRepository.GetByFilterAsync(x =>
				x.Username.Equals(loginDtoRequest.Username)
				&& x.Password.Equals(hashedPass)
			);
			if (!check.Any())
			{
				throw new CustomException.InvalidDataException($"Username or password error");
			}

			User user = check.First();
			if (user.Status == false)
			{
				throw new CustomException.InvalidDataException($"User is not active");
			}

			LoginDTOResponse loginDtoResponse = _mapper.Map<LoginDTOResponse>(user);
			Authentication authentication = new(_configuration);
			string token = authentication.GenerateJwtToken(user.id.ToString(), 15);
			return (token, loginDtoResponse);
		}
	}
}

