using Js.ContactsViewer.Server.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Js.ContactsViewer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserAccountService _userAccountService;

    public AccountController(UserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }
    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest)
    {
        var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
        var userSession = jwtAuthenticationManager
            .GenerateJwtToken(loginRequest.UserName, loginRequest.Password);

        if (userSession == null)
            return Unauthorized();
        else
            return userSession;
    }
}
