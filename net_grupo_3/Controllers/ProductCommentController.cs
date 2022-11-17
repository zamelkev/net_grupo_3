using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/productcomment")]
public class ProductCommentController {

    // Attrs
    private IProductCommentReporitory ProductCommentRepo;

    public ProductCommentController(IProductCommentReporitory productCommentRepository) {
        ProductCommentRepo = productCommentRepository;
    }

    // https://localhost:7230/api/products/findcbyid
    [HttpGet("comment/{id}")]
    public ProductComment FindCById(int id) {
        return ProductCommentRepo.FindCById(id);
    }

    // https://localhost:7230/api/products/findall
    [HttpGet]
    public List<ProductComment> FindAllC() {
        return ProductCommentRepo.FindAllC();
    }

    // https://localhost:7230/api/products/createc
    [HttpPost]
    public ProductComment CreateC(ProductComment productcomment) {
        return ProductCommentRepo.CreateC(productcomment);
    }

    // https://localhost:7230/api/products/updatec
    [HttpPut]
    public ProductComment UpdateC(ProductComment productcomment) {
        return ProductCommentRepo.UpdateC(productcomment);
    }

    // https://localhost:7230/api/products/deletebyid
    [HttpDelete]
    public bool DeleteCById(int id) {
        return ProductCommentRepo.DeleteCById(id);
    }

}
