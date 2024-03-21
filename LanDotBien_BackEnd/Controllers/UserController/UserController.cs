using System.Security.Claims;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
    /*[HttpGet("CurrentUser"), Authorize]*/
    [HttpGet("CurrentUser")]
    public ActionResult<string> GetCurrentLoggedInUser()
    {
        try
        {
            var userId = _userService.GetUserID();

            return Ok(new { UserId = userId });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateAccountDTORequest createAccountDTORequest)
    {
        User user = await _userService.Register(createAccountDTORequest);
        return Ok(createAccountDTORequest);
    }

    /*[HttpPost("RegisterForProductOwner")]
    public async Task<IActionResult> RegisterForProductOwner(CreateAccountDTORequest createAccountDTORequest)
    {
        User user = await _userService.RegisterForProductOwner(createAccountDTORequest);
        return Ok(createAccountDTORequest);
    }*/

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