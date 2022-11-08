namespace net_grupo_3.Models;

[Table("product")]
public class Product {
    // attrs
    [Key, 
    Column("id")]
    public int Id { get; set; }

    [Required,
    Column("name")]
    public string Name { get; set; }
}
