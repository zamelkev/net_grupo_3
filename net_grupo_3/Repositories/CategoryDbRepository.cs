using net_grupo_3.Models;

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


    public Category FindBySlug(string slug)
    {
        return Context.Categories
                .Where(cateogry => cateogry.Slug.ToLower().Equals(slug.ToLower()))
            .FirstOrDefault();
    }
    public Category Create(Category category)
    {
        if (category.Id > 0)
            return Update(category);

        Context.Categories.Add(category);
        Context.SaveChanges();
        return category;
    }

    public Category Update(Category category)
    {
        if (category.Id == 0)
            return Create(category);

        Context.Categories.Attach(category);

        Context.Entry(category).Property(b => b.Name).IsModified = true;
        Context.Entry(category).Property(b => b.ImgUrl).IsModified = true;
        Context.Entry(category).Property(b => b.Slug).IsModified = true;

        Context.SaveChanges();

        return FindById(category.Id);
    }

    public bool Remove(int id)
    {
        Category category = FindById(id);
        if (category == null)
            return false;

        Context.Categories.Remove(category);

        Context.SaveChanges();
        return true;
    }
}
