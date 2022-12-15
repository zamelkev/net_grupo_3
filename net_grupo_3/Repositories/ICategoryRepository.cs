namespace net_grupo_3.Repositories;

public interface ICategoryRepository
{
    Category FindById(int id);
    Category FindBySlug(string slug);

    // buscar  todos
    List<Category> FindAll();

    // guardar
    Category Create(Category category);

    // actualizar restringiendo campos
    Category Update(Category category);

    // borrar por id
    bool Remove(int id);
}
