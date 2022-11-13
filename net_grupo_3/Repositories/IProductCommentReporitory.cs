namespace net_grupo_3.Repositories; 
public interface IProductCommentReporitory {

    public ProductComment FindById(int id);

    public List<ProductComment> FindAll();

}
