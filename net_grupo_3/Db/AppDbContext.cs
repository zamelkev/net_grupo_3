
namespace net_grupo_3.Db;

public class AppDbContext : DbContext
{
    // add a DbSet for every model we have
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Client> Client { get; set; }

    public DbSet<ProductComment> ProductComments { get; set; }



    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
