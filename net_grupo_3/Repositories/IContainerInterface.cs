namespace net_grupo_3.Repositories;

public interface IContainerRepository
{
    Container FindById(int id);

    Container FindByIdWithInclude(int id);
}
