using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace net_grupo_3.Controllers;
[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase {

    private IUserRepository UserRepository;
    private readonly ILogger<UserController> Logger;
    public AccountController(IUserRepository userRepository, ILogger<UserController> logger) {
        UserRepository = userRepository;
        Logger = logger;
    }

    [HttpPost]
    public IActionResult Login(User user) {
        try
        {
            return Ok(UserRepository.Login(user));
        }
        catch (Exception ex)
        {
            Logger.LogWarning("Usuario no encontrado", ex);
            return BadRequest();
        }
    }

    [HttpPost("signup")]
    public IActionResult Signup(User user) {
        try
        {
            return Ok(UserRepository.Signup(user));
        }
        catch (Exception ex)
        {
            Logger.LogWarning("No se ha podido crear el Usuario", ex);
            return BadRequest();
        }
    }


}
