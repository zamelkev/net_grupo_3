namespace net_grupo_3.Repositories;

public interface IContainerRepository
{
    Container FindById(int id);

    Container FindByIdWithInclude(int id);

    IList<Container> FindAll();

    IList<Container> Filter(int? id, decimal? minVol, decimal? maxVol, decimal? height, decimal? width, decimal? depth, IList<Product>? products);
    
    Container Create(Container container);
    Container Update(Container container);
    bool Delete(int id);
}
