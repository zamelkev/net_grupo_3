namespace net_grupo_3.Repositories;

public class ShopDbRepository : IShopRepository
{
    private AppDbContext Context;

    public ShopDbRepository(AppDbContext context)
    {
        Context = context;
    }

    public Shop FindById(int id)
    {
        return Context.Shops.Find(id);
    }

    public Shop FindByIdWithInclude(int id)
    {
        return Context.Shops
            .Include(shop => shop.Products)
            .Where(shop => shop.Id == id)
            .FirstOrDefault();
    }

    public List<Shop> FindByNameContains(string name)
    {

        return Context.Shops
            .Where(shop => shop.Name.ToLower().Contains(name.ToLower()))
            .ToList();
    }

    public List<Shop> FindAll()
    {
        return Context.Shops.ToList();
    }

    public Shop Create(Shop shop)
    {
        if (shop.Id > 0) 
            return Update(shop);

        Context.Shops.Add(shop);
        Context.SaveChanges();
        return shop;
    }

    public Shop Update(Shop shop)
    {

        if (shop.Id == 0)
            return Create(shop);

        Context.Shops.Attach(shop);
        
        Context.Entry(shop).Property(b => b.Name).IsModified = true;
        Context.Entry(shop).Property(b => b.FoundationDate).IsModified = true;
        
        Context.SaveChanges();

        return FindById(shop.Id);
    }

    public bool Remove(int id)
    {
        Shop shop = FindById(id);
        if (shop == null)
            return false;

        Context.Shops.Remove(shop);

        Context.SaveChanges();
        return true;
    }
}
