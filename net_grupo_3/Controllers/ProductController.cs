using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController {
    // Attrs
    private IProductRepository ProductRepo;
    private IProductCommentReporitory ProductCommentRepo;

    public ProductController(IProductRepository productRepository) {
        ProductRepo = productRepository;
    }

    



    // API Methods
    // https://localhost:7230/api/products/find
    [HttpGet("{id}")]
    public Product FindById(int id) {
        return ProductRepo.FindById(id);
    }

    // https://localhost:7230/api/products/create
    [HttpPost]
    public Product Create(Product product) {
        return ProductRepo.Create(product);
    }

    // https://localhost:7230/api/products/update
    [HttpPut]
    public Product Update(Product product) {
        return ProductRepo.Update(product);
    }

    // https://localhost:7230/api/products/delete
    [HttpDelete("{id}")]
    public bool DeleteById(int id) {
        return ProductRepo.DeleteById(id);
    }

    // https://localhost:7230/api/products/findWithinclude
    [HttpGet("comment/{id}")]
    public Product FindWithInclude(int id) {
        return ProductRepo.FindByIdWithInclude(id);
    }

    // https://localhost:7230/api/products/findall
    [HttpGet]
    public List<Product> FindAll() {
        return ProductRepo.FindAll();
    }
}

