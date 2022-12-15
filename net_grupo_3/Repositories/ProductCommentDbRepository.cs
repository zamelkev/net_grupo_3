namespace net_grupo_3.Repositories; 
public class ProductCommentDbRepository : IProductCommentReporitory {

    // attrs
    private AppDbContext Context;

    // constructor
    public ProductCommentDbRepository(AppDbContext context) {
        Context = context;
    }
    // methods
    public ProductComment FindCById(int id) {
        return Context.ProductComments.Find(id);
    }
    public List<ProductComment> FindAllC() {
        return Context.ProductComments.ToList();
    }

    public ProductComment CreateC (ProductComment productcomment) {
        if (productcomment.Id > 0) // 1
            return UpdateC (productcomment);

        Context.ProductComments.Add(productcomment); // Un libro puede tener: author y categories
        
            Context.SaveChanges();
        
        return productcomment;
    }

    public ProductComment UpdateC (ProductComment productcomment) {

        if (productcomment.Id == 0)
            return CreateC (productcomment);

        // guardar solo aquellos atributos que interesen
        Context.ProductComments.Attach(productcomment);
        Context.Entry(productcomment).Property(b => b.Title).IsModified = true;
        Context.Entry(productcomment).Property(b => b.Body).IsModified = true;
        Context.SaveChanges();

        return productcomment;
    }

    public bool DeleteCById(int id) {
        ProductComment productcomment = FindCById(id);
        if (productcomment == null)
            return false;

        Context.ProductComments.Remove(productcomment);

        Context.SaveChanges();
        return true;
    }

}
