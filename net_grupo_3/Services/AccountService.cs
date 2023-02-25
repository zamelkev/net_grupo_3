using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using net_grupo_3.DTO;
using net_grupo_3.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace net_grupo_3.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public string Login(User user)
        {
            User userFromDB = _userRepository.Login(user);
            if (userFromDB is null)
                throw new WrongCredentialsException("Wrong credentials");
            return CreateToken(userFromDB);
        }
        
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role == 1 ? "User" :user.Role == 2 ? "Admin" : "Error")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: "net_grupo_3",
                audience: "Computer-Box",
                expires: DateTime.Now.AddDays(Int32.Parse(_configuration.GetSection("AppSettings:ExpireInDays").Value)),
                signingCredentials: creds);
            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
