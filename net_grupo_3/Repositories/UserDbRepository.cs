namespace net_grupo_3.Repositories;
public class UserDbRepository : IUserRepository
{
    private AppDbContext Context;
    public UserDbRepository(AppDbContext context)
    {
        Context = context;

    }
    // métodos
    public User FindById(int id)
    {
        return Context.Users.Find(id);
    }
    public IList<User> FindAll()
    {
        return Context.Users.ToList();
    }
}
