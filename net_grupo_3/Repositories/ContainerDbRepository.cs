using net_grupo_3.Models;
using System.Xml.Linq;

namespace net_grupo_3.Repositories;

public class ContainerDbRepository : IContainerRepository
{
    // attrs
    private AppDbContext Context;
    private IProductRepository ProductRepo;

    // constructor
    public ContainerDbRepository(AppDbContext context, IProductRepository productRepository)
    {
        Context = context;
        ProductRepo = productRepository;
    }
    // methods

    // basic CRUD API functionality
    public Container FindById(int id)
    {
        return Context.Containers.Find(id);
    }

    public Container FindByIdWithInclude(int id)
    {
        return Context.Containers
            .Include(container => container.Products)
            .Where(product => product.Id == id)
            .FirstOrDefault();
    }

    public IList<Container> FindAll()
    {
        return Context.Containers.ToList();
    }

    public Container Create(Container container)
    {
        // Si tiene id asignado entonces es un update y no creamos
        if (container.Id > 0) // 1
            return Update(container);

        Context.Containers.Add(container);
        Context.SaveChanges();
        return container;
    }

    public Container Update(Container container)
    {
        if (container?.Id is null || container.Id == 0)
            return Create(container);

        Context.Containers.Attach(container);

        Context.Entry(container).Property(c => c.Volume).IsModified = true;
        Context.Entry(container).Property(c => c.Height).IsModified = true;
        Context.Entry(container).Property(c => c.Width).IsModified = true;
        Context.Entry(container).Property(c => c.Depth).IsModified = true;
        Context.Entry(container).Collection(c => c.Products).IsModified = true;
        Context.SaveChanges();

        Context.Containers.Update(container);

        Context.SaveChanges();

        return container;
    }

    public bool Delete(int id)
    {
        Container container = FindById(id);
        if (container == null)
            return false;
        Context.Containers.Remove(container); // Un libro puede tener: author y categories

        Context.SaveChanges();
        return true;
    }



    // Extra API functionalites
    public IList<Container> Filter(ContainerFilter cf)
    {
        // collection declaration to apply filters to it later
        var query = Context.Containers.AsQueryable(); ;
        // filter by Id
        if (cf.Id.HasValue && cf.Id > 0)
        {
            query = query.Where(c => c.Id == cf.Id);
        }
        if(cf.Volume.HasValue && cf.Volume > 0)
        {
            query = query.Where(c => c.Volume == cf.Volume);
        }
        if (cf.Height.HasValue && cf.Height > 0)
        {
            query = query.Where(c => c.Height == cf.Height);
        }
        if (cf.Width.HasValue && cf.Width > 0)
        {
            query = query.Where(c => c.Width == cf.Width);
        }
        if (cf.Depth.HasValue && cf.Depth > 0)
        {
            query = query.Where(c => c.Depth == cf.Depth);
        }
        // Then use data (for ex. make a list).
        return query.ToList();
    }
}
