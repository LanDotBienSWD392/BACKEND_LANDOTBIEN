using System;
using System.Net;
using System.Security.Claims;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

using LanVar.Service.Interface;
using LanVar.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Tools.Tools;

namespace LanVar.Services.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserPermissionRepository _userPermissionRepository;
		private readonly IGenericRepository<User> _genericRepository;
		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAccountService _accountService;
		public UserService(
			IUserRepository userRepository,
			IMapper mapper,
			IGenericRepository<User> genericRepository,
			IConfiguration configuration,
			IUserPermissionRepository userPermissionRepository,
			IHttpContextAccessor httpContextAccessor,
			IAccountService accountService 	
			)
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_configuration = configuration;
			_genericRepository = genericRepository;
			_userPermissionRepository = userPermissionRepository;
			_httpContextAccessor = httpContextAccessor;
			_accountService = accountService;
		}

		public async Task<User> Register(CreateAccountDTORequest createAccountDTORequest)
		{
			IEnumerable<User> checkUsername =
				await _userRepository.GetByFilterAsync(x => x.username.Equals(createAccountDTORequest.Username));
			if (checkUsername.Count() != 0)
			{
				throw new InvalidDataException($"Username is exist");
			}

			var user = _mapper.Map<User>(createAccountDTORequest);
			user.permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.role.Equals("Customer"))).First().id;
			user.password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
			user.status = true;
			user.registerDay = DateTime.Now.Date;
			user.image = null;
			user.package_id = 1;
			
			await _userRepository.Add(user);
			return user;
		}

        public async Task<User> RegisterForProductOwner(CreateAccountDTORequest createAccountDTORequest)
        {
            IEnumerable<User> checkUsername =
                await _userRepository.GetByFilterAsync(x => x.username.Equals(createAccountDTORequest.Username));
            if (checkUsername.Count() != 0)
            {
                throw new InvalidDataException($"Username is exist");
            }

            var user = _mapper.Map<User>(createAccountDTORequest);
            user.permission_id = (await _userPermissionRepository.GetByFilterAsync(r => r.role.Equals("ProductOwner"))).First().id;
            user.password = EncryptPassword.Encrypt(createAccountDTORequest.Password);
            user.status = false;
            user.registerDay = DateTime.Now.Date;
            user.image = null;
            user.package_id = 1;

            await _userRepository.Add(user);
            return user;
        }

        public async Task<(string, LoginDTOResponse)> Login(LoginDTORequest loginDtoRequest)
		{
			string hashedPass = EncryptPassword.Encrypt(loginDtoRequest.Password);
			IEnumerable<User> check = await _userRepository.GetByFilterAsync(x =>
				x.username.Equals(loginDtoRequest.Username)
				&& x.password.Equals(hashedPass)
			);
			if (!check.Any())
			{
				throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),$"Username or password error");
			}

			User user = check.First();
			if (user.status == false)
			{
				throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),$"User is not active");
			}

			LoginDTOResponse loginDtoResponse = _mapper.Map<LoginDTOResponse>(user);
			Authentication authentication = new(_configuration, _userPermissionRepository);
			string token = await authentication.GenerateJwtToken(user, 15);
			return (token, loginDtoResponse);
		}

		
		public string GetUserID()
		{
			var result = string.Empty;
			if (_httpContextAccessor.HttpContext != null)
			{
				var claim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid);
				if (claim != null)
				{
					result = claim.Value;
				}
			}
			return result;
		}
    }
}

