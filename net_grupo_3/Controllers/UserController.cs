using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        // atributos
        private IUserRepository UserRepo;

        // constructores
        public UserController(IUserRepository userRpository)
        {
            UserRepo = userRpository;
        }
        
        // métodos

        [HttpGet("all"), Authorize(Roles = "User,Admin")]
        public IList<User> FindAll()
        {
            return UserRepo.FindAll();
        }

        [HttpGet("{id}")]
        public User FindById(int id)
        {
            return UserRepo.FindById(id);
        }
    }
}
