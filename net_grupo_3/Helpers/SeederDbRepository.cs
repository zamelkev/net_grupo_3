using net_grupo_3.Models;

namespace net_grupo_3.Helpers;

public class SeederDbRepository : ISeederRepository
{
    private AppDbContext Context;
    public SeederDbRepository(AppDbContext context)
    {
        Context = context;

    }
    // métodos
    public void SeedHardcodedUser()
    {
        // get user
        User existingUser = Context.Users.Where(user => user.UserName == "jjohond").FirstOrDefault();
        // check if user exists
        if (existingUser != null)
        {
            // abort operation, user already exists
            return;
        }   
        // insert
        User MasterUser = new User() { FullName = "John Johnson Davidson", Email = "jjohnsond@mail.com", UserName = "jjohond", Password = "123", Role = 1 };
        Context.Users.Add(MasterUser);
        Context.SaveChanges();
    }
}
