using System.Security.Claims;
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
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }
    [HttpGet("CurrentUser")]
    public IActionResult GetCurrentLoggedInUser()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // You can extract other user information similarly from claims

        if (userId == null)
        {
            return NotFound(); // or any other appropriate response
        }

        return Ok(userId);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterRequest userRegisterRequest)
    {
        User user = await _userService.Register(userRegisterRequest);
        return Ok(userRegisterRequest);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginDTORequest loginDtoRequest)
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