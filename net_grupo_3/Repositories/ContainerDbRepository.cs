using net_grupo_3.Models;
using System.Xml.Linq;

namespace net_grupo_3.Repositories;

public class ContainerDbRepository : IContainerRepository
{
    // attrs
    private AppDbContext Context;

    // constructor
    public ContainerDbRepository(AppDbContext context)
    {
        Context = context;
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
            .Where(container => container.Id == id)
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

    public IList<Container> Filter(int? id, decimal? minVol, decimal? maxVol, decimal? height, decimal? width, decimal? depth, IList<Product>? products)
    {
        throw new NotImplementedException();
    }

    // Extra API functionalites

}
