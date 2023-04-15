using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SharpLive.Controllers;

[ApiController]
[Route("[action]")]
public class AccountController : ControllerBase
{
    [HttpGet]
    public IActionResult Login()
    {
        return Challenge(new AuthenticationProperties { RedirectUri = "/" }, DiscordAuthenticationDefaults.AuthenticationScheme);
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return Redirect("/");
    }
}