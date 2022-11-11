namespace net_grupo_3.Repositories; 
public class ProductCommentDbRepository : IProductCommentReporitory {

    // attrs
    private AppDbContext Context;

    // constructor
    public ProductCommentDbRepository(AppDbContext context) {
        Context = context;
    }
    // methods
    public ProductComment FindById(int id) {
        return Context.productComments.Find(id);
    }
    public List<ProductComment> FindAll() {
        return Context.productComments.ToList();
    }

}
