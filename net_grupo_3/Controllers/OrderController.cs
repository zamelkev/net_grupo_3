using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    // attrs
    private IOrderRepository OrderRepo;
    private readonly IStockService _stockService;
    private readonly ILogger<OrderController> _logger;

    // constructor
    public OrderController(IOrderRepository orderRepository, IStockService stockService, ILogger<OrderController> logger)
    {
        OrderRepo = orderRepository;
        _stockService = stockService;
        _logger = logger;
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
    public IActionResult Create(Order order)
    {
        //return OrderRepo.Create(order);
        _logger.LogInformation("Executing order.");

        try
        {

            return Ok(_stockService.Create(order));
        }
        catch (OutOfStockException e)
        {
            _logger.LogWarning("Error: {message}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
        catch (Exception)
        {
            return Problem("Error executing the order");
        }
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
    [HttpGet("include/{id}")]
    public Order FindByIdInclude(int id)
    {
        return OrderRepo.FindOrderByIdInclude(id);
    }
}
