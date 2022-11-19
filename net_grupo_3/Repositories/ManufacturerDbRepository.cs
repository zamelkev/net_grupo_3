using net_grupo_3.Models;

namespace net_grupo_3.Repositories
{
    public class ManufacturerDbRepository : IManufacturerRepository
    {
        private AppDbContext Context;

        public ManufacturerDbRepository(AppDbContext context)
        {
            Context = context;
        }

        public Manufacturer FindById(int id)
        {
            return Context.Manufacturers.Find(id);
        }

        public Manufacturer FindByIdWithInclude(int id)
        {
            return Context.Manufacturers
                .Include(manufacturer => manufacturer.Products)
                .Where(manufacturer => manufacturer.Id == id)
                .FirstOrDefault();
        }

        public List<Manufacturer> FindByNameContains(string name)
        {

            return Context.Manufacturers
                .Where(manufacturer => manufacturer.Name.ToLower().Contains(name.ToLower()))
            .ToList();
        }

        public List<Manufacturer> FindAll()
        {
            return Context.Manufacturers.ToList();
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            if (manufacturer.Id > 0)
                return Update(manufacturer);

            Context.Manufacturers.Add(manufacturer);
            Context.SaveChanges();
            return manufacturer;
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {

            if (manufacturer.Id == 0)
                return Create(manufacturer);

            Context.Manufacturers.Attach(manufacturer);

            Context.Entry(manufacturer).Property(b => b.Name).IsModified = true;
            Context.Entry(manufacturer).Property(b => b.FoundationDate).IsModified = true;

            Context.SaveChanges();

            return FindById(manufacturer.Id);
        }

        public bool Remove(int id)
        {
            Manufacturer manufacturer = FindById(id);
            if (manufacturer == null)
                return false;

            Context.Manufacturers.Remove(manufacturer);

            Context.SaveChanges();
            return true;
        }
    }
}
