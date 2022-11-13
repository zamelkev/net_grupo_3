
namespace net_grupo_3.Db;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    // add a DbSet for every model we have
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }
}
