namespace net_grupo_3.Repositories;
public class CategoryDbRepository : ICategoryRepository
{


    private AppDbContext Context;
   


    public CategoryDbRepository(AppDbContext context)
    {
        Context = context;

    }

    // métodos
    public Category FindById(int id)
    {
        return Context.Categories.Find(id);
    }

    public List<Category> FindAll()
    {
        return Context.Categories.ToList();
    }

    
}
