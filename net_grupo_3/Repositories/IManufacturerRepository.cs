namespace net_grupo_3.Repositories
{
    public interface IManufacturerRepository
    {
        // buscar por id
        Manufacturer FindById(int id);

        // buscar por id incluyendo asociaciones
        Manufacturer FindByIdWithInclude(int id);

        Manufacturer FindBySlug(string slug);

        // buscar por Name que contenga el texto
        List<Manufacturer> FindByNameContains(string name);

        // buscar  todos
        List<Manufacturer> FindAll();

        // guardar
        Manufacturer Create(Manufacturer manufacturer);

        // actualizar restringiendo campos
        Manufacturer Update(Manufacturer manufacturer);

        // borrar por id
        bool Remove(int id);
    }
}
