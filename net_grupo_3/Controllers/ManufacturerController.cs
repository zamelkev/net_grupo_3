using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

// [EnableCors("AllowAll")]
[ApiController]
[Route("api/manufacturers")]
public class ManufacturersController
{

    // atributos
    private IManufacturerRepository ManufacturerRepo;

    // constructores
    public ManufacturersController(IManufacturerRepository ManufacturerRepository)
    {
        ManufacturerRepo = ManufacturerRepository;
    }

    // métodos

    [HttpGet("all")]
    public List<Manufacturer> FindAll()
    {
        return ManufacturerRepo.FindAll();
    }

    [HttpGet("{id}")]
    public Manufacturer FindById(int id)
    {
        return ManufacturerRepo.FindById(id);
    }

    [HttpGet("include/{id}")]
    public Manufacturer FindByIdWithInclude(int id)
    {
        return ManufacturerRepo.FindByIdWithInclude(id);
    }

    [HttpGet("manufacturer/{slug}")]
    public Manufacturer FindBySlug(string slug)
    {
        return ManufacturerRepo.FindBySlug(slug);
    }

    [HttpGet("name/{name}")]
    public List<Manufacturer> FindByNameContains(string name)
    {
        return ManufacturerRepo.FindByNameContains(name);
    }

    [HttpPost]
    public Manufacturer Create(Manufacturer manufacturer)
    {
        var manufacturerDB = ManufacturerRepo.Create(manufacturer); ;
        return manufacturerDB;
    }

    [HttpPut]
    public Manufacturer Update(Manufacturer manufacturer)
    {
        return ManufacturerRepo.Update(manufacturer);
    }

    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        ManufacturerRepo.Remove(id);
    }
}