namespace net_grupo_3.Repositories;

public interface IUserRepository
{
    User FindById(int id);
    IList<User> FindAll();
}
