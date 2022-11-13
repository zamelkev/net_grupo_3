namespace net_grupo_3.Repositories;

public class OrderDbRepository : IOrderRepository
{
    // attrs
    private AppDbContext Context;

    // constructor
    public OrderDbRepository(AppDbContext context)
    {
        Context = context;
    }

    // methods
    public Order FindById(int id)
    {
        return Context.Orders.Find(id);
    }
    public IList<Order> FindAll()
    {
        return Context.Orders.ToList();
    }


    public Order FindByIdIncludeClient(int id)
    {
        return Context.Orders
            .Include(order => order.Client)
            .Where(order => order.Id == id)
            .FirstOrDefault();
    }
}
