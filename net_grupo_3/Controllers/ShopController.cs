using Microsoft.AspNetCore.Mvc;

namespace net_grupo_3.Controllers;

// [EnableCors("AllowAll")]
[ApiController]
[Route("api/shops")]
public class ShopController
{

    // atributos
    private IShopRepository ShopRepo;

    // constructores
    public ShopController(IShopRepository ShopRepository)
    {
        ShopRepo = ShopRepository;
    }

    // métodos

    [HttpGet("all")]
    public List<Shop> FindAll()
    {
        return ShopRepo.FindAll();
    }

    [HttpGet("{id}")]
    public Shop FindById(int id)
    {
        return ShopRepo.FindById(id);
    }

    [HttpGet("include/{id}")]
    public Shop FindByIdWithInclude(int id)
    {
        return ShopRepo.FindByIdWithInclude(id);
    }

    [HttpGet("name/{name}")] 
    public List<Shop> FindByNameContains(string name)
    {
        return ShopRepo.FindByNameContains(name);
    }

    [HttpPost]
    public Shop Create(Shop shop)
    {
        var shopDB = ShopRepo.Create(shop);;
        return shopDB;
    }

    [HttpPut]
    public Shop Update(Shop shop)
    {
        return ShopRepo.Update(shop);
    }

    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        ShopRepo.Remove(id);
    }
}
