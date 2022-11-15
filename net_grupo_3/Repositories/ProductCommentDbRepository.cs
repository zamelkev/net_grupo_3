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
        return Context.ProductComments.Find(id);
    }
    public List<ProductComment> FindAll() {
        return Context.ProductComments.ToList();
    }

    public ProductComment Create(ProductComment productcomment) {
        if (productcomment.Id > 0) // 1
            return Update(productcomment);

        Context.ProductComments.Add(productcomment); // Un libro puede tener: author y categories
        Context.SaveChanges();
        return productcomment;
    }

    public ProductComment Update(ProductComment productcomment) {

        if (productcomment.Id == 0)
            return Create(productcomment);

        // guardar solo aquellos atributos que interesen
        Context.ProductComments.Attach(productcomment);

        Context.Entry(productcomment).Property(b => b.Body).IsModified = true;
        Context.Entry(productcomment).Property(b => b.Body).IsModified = true;
        Context.SaveChanges();

        return FindById(productcomment.Id);
    }

    public bool DeleteById(int id) {
        ProductComment productcomment = FindById(id);
        if (productcomment == null)
            return false;

        Context.ProductComments.Remove(productcomment);

        Context.SaveChanges();
        return true;
    }

}
