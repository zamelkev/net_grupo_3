using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;
[ApiController]
[Route("api/categories")]
public class CategoryController
{
    // atributos
    private ICategoryRepository CategoryRepo;

    // constructores
    public CategoryController(ICategoryRepository categoryRepository)
    {
        CategoryRepo = categoryRepository;
    }

    [HttpGet("all")]
    public List<Category> FindAll()
    {
        return CategoryRepo.FindAll();
    }

    [HttpGet("{id}")]
    public Category FindById(int id)
    {
        return CategoryRepo.FindById(id);
    }
    [HttpGet("category/{slug}")]
    public Category FindBySlug(string slug)
    {
        return CategoryRepo.FindBySlug(slug);
    }
    [HttpPost]
    public Category Create(Category category)
    {
        var categoryDB = CategoryRepo.Create(category); ;
        return categoryDB;
    }

    [HttpPut]
    public Category Update(Category category)
    {
        return CategoryRepo.Update(category);
    }

    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        CategoryRepo.Remove(id);
    }
}
