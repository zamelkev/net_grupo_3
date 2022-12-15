namespace net_grupo_3.Repositories;

public interface IOrderDetailRepository
{


    List<OrderDetail> FindAll();
    List<OrderDetail> FindByOrder(int id);
}
