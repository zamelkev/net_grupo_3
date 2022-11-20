using System.Net;

namespace net_grupo_3.Repositories; 
public interface IProductRepository {

    
    Product FindById(int id);

    Product FindByIdWithInclude(int id);

    List<Product> FindAll();

    IList<Product> FindByContainerId(int id);

    public IList<Product> FindProductsByManufacturerId(int manufacturerId);

    Product Create(Product product);

    Product Update(Product product);

    bool DeleteById(int id);

}
