namespace net_grupo_3.Repositories;

public interface IOrderRepository
{
    Order FindById(int id);

    Order FindByIdIncludeClient(int id);

    IList<Order> FindAll();


    Order Create(Order order);
    Order Update(Order order);
    bool Delete(int id);
    IList<Order> Filter(OrderFilter of);
}
