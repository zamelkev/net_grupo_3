using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using net_grupo_3.Models;
using System.Net;
using System.Security.Claims;

namespace net_grupo_3.Controllers;
[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase {

    private IUserRepository UserRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepo;
    private readonly IAccountService _accountService;
    private readonly ILogger<UserController> Logger;
    public AccountController(IUserRepository userRepository, ILogger<UserController> logger, IAccountService accountService)
    {
        UserRepository = userRepository;
        _accountService = accountService;
        Logger = logger;
    }

    [HttpPost]
    public IActionResult Login(User user) {
        try
        {
            //return Ok(UserRepository.Login(user));
            return Ok(_accountService.Login(user));

        }
        catch (WrongCredentialsException ex)
        {
            Logger.LogWarning("Credenciales erroneos", ex);
            return BadRequest("Credenciales erroneos.");
        }
        catch (Exception ex)
        {
            Logger.LogWarning("Error de login", ex);
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

    [HttpGet("id/{userName}")]
    public int FindUserIdByUserName(string userName) { 
        return UserRepository.FindByUserName(userName);
    }

    [HttpPost("refresh-token")]
    public IActionResult RefreshToken(RefreshTokenDTO refreshRequest)
    {
        var refreshToken = Request.Cookies["refreshToken"];

        var user = UserRepository.FindByUserName(refreshRequest.userName);




        if (!user.RefreshToken.Equals(refreshToken))
        {
            return Unauthorized("Invalid Refresh Token.");
        }
        else if (user.TokenExpires < DateTime.Now)
        {
            return Unauthorized("Token expired.");
        }

        string token = CreateToken(user);
        var newRefreshToken = GenerateRefreshToken();
        SetRefreshToken(newRefreshToken);

        return Ok(token);
    }

}
