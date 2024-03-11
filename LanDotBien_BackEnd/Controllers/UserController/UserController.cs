using LanVar.Core.Entity;
using LanVar.Service.DTO;
using LanVar.Service.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LanDotBien_BackEnd.Controllers.UserController;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
    {
        User user = await _userService.Register(userRegisterRequest);
        return Ok(userRegisterRequest);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser(LoginDTORequest loginDtoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (string, LoginDTOResponse) tuple = await _userService.Login(loginDtoRequest);
        if (tuple.Item1 == null)
        {
            return Unauthorized();
        }

        Dictionary<string, object> result = new()
        {
            { "token", tuple.Item1 },
            { "user", tuple.Item2 ?? null }
        };
        return Ok(result);
    }

}