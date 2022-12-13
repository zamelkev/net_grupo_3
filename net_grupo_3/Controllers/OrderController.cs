using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController
{
    // attrs
    private IOrderRepository OrderRepo;

    // constructor
    public OrderController(IOrderRepository orderRepository)
    {
        OrderRepo = orderRepository;
    }

    // methods
    // https://localhost:7230/api/orders/1
    [HttpGet("{id}")]
    public Order FindById(int id)
    {
        return OrderRepo.FindById(id);
    }

    // https://localhost:7230/api/books/1
    [HttpGet("include_client/{id}")]
    public Order FindWithInclude(int id)
    {
        return OrderRepo.FindByIdIncludeClient(id);
    }

    [HttpGet]
    public IList<Order> FindAll()
    {
        return OrderRepo.FindAll();
    }
    [HttpPost]
    public Order Create(Order order)
    {
        return OrderRepo.Create(order);
    }

    [HttpPut]
    public Order Update(Order author)
    {
        return OrderRepo.Update(author);
    }

    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        OrderRepo.Delete(id);
    }

    // filters
    [HttpPost("filter")]
    public IList<Order> FilterOrder(OrderFilter of)
    {
        return OrderRepo.Filter(of);
    }
    [HttpGet("client_id/{id}")]
    public List<Order> FindByClientId(int id)
    {
        return OrderRepo.FindOrdersByClient(id);
    }
}
