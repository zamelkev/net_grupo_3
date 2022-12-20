using System.Net;

namespace net_grupo_3.Repositories; 
public interface IProductRepository {

    
    Product FindById(int id);

    Product FindByIdWithInclude(int id);
    List<Product> FindByIdsWithInclude(List<int> ids);

    List<Product> FindAll();

    Product FindBySlug(string slug);
    IList<Product> FindByManufactuerSlug(string slug);
    IList<Product> FindByCategorySlug(string slug);
    public IList<Product> FindProductsByManufacturerId(int manufacturerId);
    public IList<Product> FindProductsByCategoryId(int categoryId);
    Product Create(Product product);

    Product Update(Product product);

    bool DeleteById(int id);

}
