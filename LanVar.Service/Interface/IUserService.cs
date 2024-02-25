using LanVar.Core.Entity;
using LanVar.Service.DTO;
using LanVar.Service.DTO.response;

namespace LanVar.Service.Interface;

public interface IUserService
{
    Task<User> Register(UserRegisterRequest userRegisterRequest); 
    Task<(string, LoginDTOResponse)> Login(LoginDTORequest loginDtoRequest);
}