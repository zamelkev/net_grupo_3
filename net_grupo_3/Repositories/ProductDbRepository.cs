namespace net_grupo_3.Repositories;

public class ProductDbRepository : IProductRepository
{
    // attrs
    private AppDbContext Context;

    // constructor
    public ProductDbRepository(AppDbContext context)
    {
        Context = context;
    }
    // methods
    public Product FindById(int id)
    {
        return Context.Products.Find(id);
    }

}
