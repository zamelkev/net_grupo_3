using System.Net;

namespace net_grupo_3.Repositories; 
public interface IProductRepository {

    
    Product FindById(int id);


   /*
    List<Product> FindAll();

    // guardar
    Product Create(Product product);

    bool RemoveById(int id);
   */
}
