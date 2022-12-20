namespace net_grupo_3.Services {
    public interface IUserService {
        User FindById(int id);
        IList<User> FindAll();
        User Login(User user);
    }
}
