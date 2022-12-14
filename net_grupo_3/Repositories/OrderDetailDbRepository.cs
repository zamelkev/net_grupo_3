namespace net_grupo_3.Repositories;

public class OrderDetailDbRepository : IOrderDetailRepository
{
    // attrs
    private readonly  AppDbContext _context;

    // constructor
    public OrderDetailDbRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<OrderDetail> FindAll()
    {
        return _context.OrderDetails.ToList();
    }

    public List<OrderDetail> FindByOrder(int id)
    {
        return _context.OrderDetails
            .Where(od => od.OrderId == id)
            .ToList();
    }
    public List<OrderDetail> FindByOrders(List<int> id)
    {
        return _context.OrderDetails
            .Where(od => id.Contains((int)od.OrderId))
            .ToList();
    }
}
