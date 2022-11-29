using net_grupo_3.Models;
using System.Xml.Linq;

namespace net_grupo_3.Repositories
{
    public class ManufacturerDbRepository : IManufacturerRepository
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;

        public ManufacturerDbRepository(AppDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public Manufacturer FindById(int id)
        {
            return _context.Manufacturers.Find(id);
        }

        public Manufacturer FindByIdWithInclude(int id)
        {
            return _context.Manufacturers
                .Include(manufacturer => manufacturer.Products)
                .Where(manufacturer => manufacturer.Id == id)
                .FirstOrDefault();
        }

        public List<Manufacturer> FindByNameContains(string name)
        {

            return _context.Manufacturers
                .Where(manufacturer => manufacturer.Name.ToLower().Contains(name.ToLower()))
            .ToList();
        }

        public Manufacturer FindBySlug(string slug)
        {
            return _context.Manufacturers
                .Where(manufacturer => manufacturer.Slug.ToLower().Equals(slug.ToLower()))
            .FirstOrDefault();
        }

        public List<Manufacturer> FindAll()
        {
            return _context.Manufacturers.ToList();
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            if (manufacturer.Id > 0)
                return Update(manufacturer);

            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
            return manufacturer;
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {

            if (manufacturer.Id == 0)
                return Create(manufacturer);

            _context.Manufacturers.Attach(manufacturer);

            _context.Entry(manufacturer).Property(b => b.Name).IsModified = true;
            _context.Entry(manufacturer).Property(b => b.Slug).IsModified = true;
            _context.Entry(manufacturer).Property(b => b.ImgUrl).IsModified = true;
            _context.Entry(manufacturer).Property(b => b.FoundationDate).IsModified = true;

            _context.SaveChanges();

            return FindById(manufacturer.Id);
        }

        public bool Remove(int id)
        {
            Manufacturer manufacturer = FindById(id);
            if (manufacturer == null)
                return false;

            // unlink FKs from product before deleting manufacturer
            IList<Product> ProductsFromManufacturer =  _productRepository.FindProductsByManufacturerId(id);
            foreach (Product product in ProductsFromManufacturer)
                if (product.ManufacturerId == id) 
                {
                    product.ManufacturerId = null;
                    _productRepository.Update(product);
                }
                    
            // finally remove
            _context.Manufacturers.Remove(manufacturer);

            _context.SaveChanges();
            return true;
        }
    }
}
