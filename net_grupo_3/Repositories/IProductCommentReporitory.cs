namespace net_grupo_3.Repositories; 
public interface IProductCommentReporitory {

    public ProductComment FindCById(int id);

    public List<ProductComment> FindAllC();

    ProductComment CreateC(ProductComment productcomment);

    ProductComment UpdateC(ProductComment productcomment);

    bool DeleteCById(int id);

}
