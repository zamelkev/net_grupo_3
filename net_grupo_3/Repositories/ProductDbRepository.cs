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
    public Product FindBySlug(string slug)
    {
        return Context.Products
            .Include(p => p.Manufacturer)
            .Include(p => p.Category)
            .Where(p => p.Slug == slug)
            .FirstOrDefault();
    }
    public IList<Product> FindByManufactuerSlug(string slug)
    {
        return Context.Products
            .Include(p => p.Manufacturer)
            .Include(p => p.Category)
            .Where(p => p.Manufacturer.Slug == slug)
            .ToList();
    }

    public IList<Product> FindByCategorySlug(string slug)
    {
        return Context.Products
            .Include(p => p.Manufacturer)
            .Include(p => p.Category)
            .Where(p => p.Category.Slug == slug)
            .ToList();
    }
    public List<Product> FindAll() {
        return Context.Products.ToList();
    }

    public bool ExistsById(int id) {
        Product existentProduct = FindById(id);
        if (existentProduct != null) return true;
        return false;
    }

    public Product Create(Product product) {
        
        if (product.Id > 0) // 1
            return Update(product);

        Context.Products.Add(product); 
        Context.SaveChanges();
        return product;
    }

    public Product Update(Product product) {

        if (product.Id == 0)
            return Create(product);

        // guardar solo aquellos atributos que interesen
        Context.Products.Attach(product);

        Context.Entry(product).Property(b => b.Name).IsModified = true;
        Context.Entry(product).Property(b => b.Price).IsModified = true;
        Context.Entry(product).Property(b => b.Cost).IsModified = true;
        Context.Entry(product).Property(b => b.Stock).IsModified = true;
        Context.Entry(product).Property(b => b.Tax).IsModified = true;
        Context.Entry(product).Property(b => b.ReleaseDate).IsModified = true;
        Context.Entry(product).Property(b => b.ManufacturerId).IsModified = true;
        Context.Entry(product).Property(b => b.CategoryId).IsModified = true;
        Context.SaveChanges();

        return product;
    }

    public bool DeleteById(int id) {
        Product product = FindById(id);
        if (product == null)
            return false;

        Context.Products.Remove(product);

        Context.SaveChanges();
        return true;
    }

    public Product FindByIdWithInclude(int id) {
        return Context.Products
            .Include(product => product.Category)
            .Include(product => product.Manufacturer)
            .Where(product => product.Id == id)
            .FirstOrDefault();
    }

    public IList<Product> FindByContainerId(int containerId)
    {
        return Context.Products
            .Include(product => product.Container)
            .Where(product => product.ContainerId == containerId)
            .ToList();
    }

    public IList<Product> FindProductsByManufacturerId(int manufacturerId) {

        return Context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .Where(p => p.Manufacturer.Id == manufacturerId)
                .ToList();

    }

}
