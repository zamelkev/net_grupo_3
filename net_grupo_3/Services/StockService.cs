namespace net_grupo_3.Services;

public class StockService : IStockService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public StockService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }
    public Order Create(Order order)
    {
        // if the stock is right
        foreach (var od in order.OrderDetails)
            if (od.Quantity > _productRepository.FindById((int)od.ProductId).Stock)
                throw new OutOfStockException($"Product {_productRepository.FindById((int)od.ProductId).Name} didn't have enough stock to meet the order.");
        // create order
        Order myOrder = _orderRepository.Create(order);
        // update stock of all products according to order
        if (myOrder.Id != null)
        {
            foreach (var od in order.OrderDetails)
            {
                Product myProduct = _productRepository.FindById((int)od.ProductId);
                myProduct.Stock -= od.Quantity;
                _productRepository.Update(myProduct);
            }
        }
        return myOrder;
    }

}
