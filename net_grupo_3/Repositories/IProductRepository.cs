﻿using System.Net;

namespace net_grupo_3.Repositories; 
public interface IProductRepository {

    
    Product FindById(int id);

    Product FindByIdWithInclude(int id);

    List<Product> FindAll();

    Product FindBySlug(string slug);
    IList<Product> FindByManufactuerSlug(string slug);
    IList<Product> FindByCategorySlug(string slug);
    IList<Product> FindByContainerId(int id);

    Product Create(Product product);

    Product Update(Product product);

    bool DeleteById(int id);

}
