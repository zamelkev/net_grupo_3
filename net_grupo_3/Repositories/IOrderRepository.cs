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
    // predicted for buying functionality
    List<Order> FindOrdersByClient(int id);
    Order FindOrderByIdInclude(int id);
}
