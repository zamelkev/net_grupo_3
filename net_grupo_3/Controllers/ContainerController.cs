using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

[ApiController]
[Route("api/containers")]
public class ContainerController
{
    // attrs
    private IContainerRepository ContainerRepo;

    // constructor
    public ContainerController(IContainerRepository containerRepository)
    {
        ContainerRepo = containerRepository;
    }

    // API Methods
    // https://localhost:7230/api/containers/1
    [HttpGet("{id}")]
    public Container FindById(int id)
    {
        return ContainerRepo.FindById(id);
    }

    // https://localhost:7230/api/containers/products/1
    [HttpGet("products/{id}")]
    public Container FindWithInclude(int id)
    {
        return ContainerRepo.FindByIdWithInclude(id);
    }
}
