namespace net_grupo_3.Repositories;

public interface IShopRepository
{
    // buscar por id
    Shop FindById(int id);

    // buscar por id incluyendo asociaciones
    Shop FindByIdWithInclude(int id);

    // buscar por Name que contenga el texto
    List<Shop> FindByNameContains(string name);

    // buscar  todos
    List<Shop> FindAll();

    // guardar
    Shop Create(Shop shop);

    // actualizar restringiendo campos
    Shop Update(Shop shop);

    // borrar por id
    bool Remove(int id);
}
