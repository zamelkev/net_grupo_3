
namespace net_grupo_3.Db;

public class AppDbContext : DbContext
{
    // add a DbSet for every model we have
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Client> Client { get; set; }

    public DbSet<ProductComment> ProductComments { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Container> Containers { get; set; }



    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }
}
