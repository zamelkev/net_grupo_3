using net_grupo_3.Models;

namespace net_grupo_3.Repositories
{
    public class RefreshTokenDbRepository : IRefreshTokenRepository
    {
        private AppDbContext Context;
        public RefreshTokenDbRepository(AppDbContext context)
        {
            Context = context;
        }
        public RefreshToken FindById(int id)
        {
            return Context.RefreshTokens.Find(id);
        }
        public RefreshToken FindByRefreshToken(string refreshToken)
        {
            return Context.RefreshTokens
                .Where(r => r.Token == refreshToken)
                .First();
        }

        public RefreshToken FindByUserId(int userId)
        {
            return Context.RefreshTokens
                .Where(r => r.UserId == userId)
                .First();
        }

        public RefreshToken Create(string refreshToken, int userId)
        {
            RefreshToken token = new RefreshToken();
            token.Token = refreshToken;
            token.UserId = userId;
            Context.RefreshTokens.Add(token);
            Context.SaveChanges();
            return token;
        }
        public String Revoke(string refreshToken)
        {
            RefreshToken token = FindByRefreshToken(refreshToken);
            Context.RefreshTokens.Remove(token);
            Context.SaveChanges();
            return refreshToken;
        }
    }
}
