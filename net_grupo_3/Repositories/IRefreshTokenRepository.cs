namespace net_grupo_3.Repositories
{
    public interface IRefreshTokenRepository
    {
        RefreshToken FindById(int id);
        RefreshToken FindByRefreshToken(String refreshToken);
        RefreshToken FindByUserId(int userId);
        RefreshToken Create(String refreshToken, int userId);
        String Revoke(String refreshToken);
    }
}
