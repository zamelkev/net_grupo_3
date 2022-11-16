namespace net_grupo_3.Repositories;

public interface IContainerRepository
{
    Container FindById(int id);

    Container FindByIdWithInclude(int id);
    IList<Container> FindAll();
    Container Create(Container container);
    Container Update(Container container);
    bool Delete(int id);
    IList<Container> Filter(ContainerFilter cf);

}
