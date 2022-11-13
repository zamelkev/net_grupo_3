namespace net_grupo_3.Models; 
public class ProductComment {

    public int Id { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public DateTime PostDate { get; set;}
    
    [JsonIgnore]
    public Product? Product { get; set; }
    public int ProductId { get; set; }

}
