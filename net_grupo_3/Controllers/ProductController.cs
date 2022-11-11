using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/books")]
public class ProductController
{
    // Attrs
    private IProductRepository ProductRepo;
    private IProductCommentReporitory ProductCommentRepo;

    public ProductController(IProductRepository productRepository)
    {
        ProductRepo = productRepository;
    }

    public ProductController(IProductRepository productRepo, IProductCommentReporitory productCommentRepo) : this(productRepo) {
        ProductCommentRepo = productCommentRepo;
    }



    // API Methods
    // https://localhost:7230/api/books/1
    [HttpGet("{id}")]
    public Product FindById(int id)
    {
        return ProductRepo.FindById(id);
    }

/*
    // https://localhost:7230/api/books/findall
    [HttpGet]
    public List<Product> FindAll()
    {
        return ProductRepo.FindAll();
    }*/
}
