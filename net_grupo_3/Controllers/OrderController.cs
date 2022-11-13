using Microsoft.AspNetCore.Mvc;
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
}
