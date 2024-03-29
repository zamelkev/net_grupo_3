﻿namespace net_grupo_3.Repositories;
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

    public User Login(User user) {
        return Context.Users
            .Where(u => u.Email == user.Email)
            .Where(u => u.Password == user.Password)
            .First();
    }

    public User Signup(User user) {
        Context.Users.Add(user);
        Context.SaveChanges();
        return user;
    }

    public int FindByUserName(string userName) {
        return Context.Users.Where(u => u.UserName == userName).First().Id;
    }
}
