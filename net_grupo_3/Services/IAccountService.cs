namespace net_grupo_3.Services
{
    public interface IAccountService
    {
        RefreshToken GenerateRefreshToken();
        string Login(User user);
    }
}
