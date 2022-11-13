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
}
