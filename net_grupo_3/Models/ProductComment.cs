namespace net_grupo_3.Models;
[Table("product_comment")]
public class ProductComment {

    [Key,
    Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("post_date")]
    public DateTime PostDate { get; set;}
    [JsonIgnore]
    public Product? Product { get; set; }
    public int ProductId { get; set; }
    // test
}
