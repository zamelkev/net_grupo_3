namespace net_grupo_3.Repositories;

public interface IUserRepository
{
    

    User FindById(int id);
    IList<User> FindAll();
    User Login(User user);
    User Signup(User user);
    int FindByUserName(string userName);
}
