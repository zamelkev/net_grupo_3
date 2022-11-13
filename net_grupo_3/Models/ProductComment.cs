namespace net_grupo_3.Models; 
public class ProductComment {

    public int Id { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public DateTime PostDate { get; set;}

    public Product Product { get; set; }
    public int ProductId { get; set; }

    //public ProductComment(int id, string title, string body, DateTime postDate, Product product, int productId) {
    //    Id = id;
    //    Title = title;
    //    Body = body;
    //    PostDate = postDate;
    //    Product = product;
    //    ProductId = productId;
    //}
}
