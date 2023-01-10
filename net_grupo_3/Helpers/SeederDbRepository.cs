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
        User existingUser = null;
        User existingAdmin = null;
        // get user
        try
        {
            existingUser = Context.Users.Where(user => user.UserName == "jjohond").FirstOrDefault();
            existingAdmin = Context.Users.Where(user => user.UserName == "admin").Where(user => user.Role == 2).FirstOrDefault();
            // check if user exists

        }
        catch (Exception)
        {

        }

        if (existingUser == null)
        {
            // insert
            User MasterUser = new User() { FullName = "John Johnson Davidson", Email = "jjohnsond@mail.com", UserName = "jjohond", Password = "123", Role = 1 };
            Context.Users.Add(MasterUser);
            Context.SaveChanges();
        }

        if (existingAdmin == null)
        {
            // insert
            User MasterUser = new User() { FullName = "Admin Adminson", Email = "admin@admin.es", UserName = "admin", Password = "admin123", Role = 2 };
            Context.Users.Add(MasterUser);
            Context.SaveChanges();
        }

    }
}
