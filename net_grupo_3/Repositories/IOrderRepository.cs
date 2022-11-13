namespace net_grupo_3.Repositories;

public interface IOrderRepository
{
    Order FindById(int id);

    IList<Order> FindAll();

    Order FindByIdIncludeClient(int id);

}
