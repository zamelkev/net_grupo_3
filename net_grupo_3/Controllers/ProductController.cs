using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController {
    // Attrs
    private IProductRepository ProductRepo;
    
    public ProductController(IProductRepository productRepository) {
        ProductRepo = productRepository;
    }

    



    // API Methods
    // https://localhost:7230/api/products/find
    [HttpGet("{id}")]
    public Product FindById(int id) {
        return ProductRepo.FindById(id);
    }
    // https://localhost:7230/api/products/findWithinclude
    [HttpGet("include/{id}")]
    public Product FindWithInclude(int id)
    {
        return ProductRepo.FindByIdWithInclude(id);
    }
    [HttpGet("product/{slug}")]
    public Product FindBySlug(string slug)
    {
        return ProductRepo.FindBySlug(slug);
    }
    [HttpGet("manufactuer/slug/{slug}")]
    public IList<Product> FindByManufactuerSlug(string slug)
    {
        return ProductRepo.FindByManufactuerSlug(slug);
    }
    [HttpGet("category/slug/{slug}")]
    public IList<Product> FindByCategorySlug(string slug)
    {
        return ProductRepo.FindByCategorySlug(slug);
    }
    // https://localhost:7230/api/products/findall
    [HttpGet]
    public List<Product> FindAll()
    {
        return ProductRepo.FindAll();
    }
    // https://localhost:7230/api/products/find_by_container
    [HttpGet("container/{id}")]


    // https://localhost:7230/api/products/find_by_manufacturer
    [HttpGet("manufacturer/{manufacturer_id}")]
    public IList<Product> FindProductsByManufacturerId(int manufacturer_id) {

        return ProductRepo.FindProductsByManufacturerId(manufacturer_id);

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



}

