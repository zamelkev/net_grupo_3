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
            if (od.Quantity > _productRepository.FindById((int)od.ProductId)?.Stock)
            {
                Product p = _productRepository.FindById((int)od.ProductId);
                throw new OutOfStockException(
                    $"El producto {p.Name} no dispone de suficiente stock para completar la orden. Stock del producto: {p.Stock}, cantidad de pedido: {od.Quantity}"
                    );
            }
                
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
