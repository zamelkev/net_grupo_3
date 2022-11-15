using System.Net;

namespace net_grupo_3.Repositories; 
public interface IProductRepository {

    
    Product FindById(int id);

    Product FindByIdWithInclude(int id);

    List<Product> FindAll();

    Product Create(Product product);

    Product Update(Product product);

    bool DeleteById(int id);

}
