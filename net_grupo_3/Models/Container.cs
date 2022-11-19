namespace net_grupo_3.Models;

[Table("container")]
public class Container
{
    [Key,
    Column("id")]  
    public int Id { get; set; }

    [Column("volume"), Precision(14, 2)]
    public decimal? Volume { get; set; }

    [Column("height"), Precision(14, 2)]
    public decimal Height { get; set; }

    [Column("width"), Precision(14, 2)]
    public decimal Width { get; set; }

    [Column("depth"), Precision(14, 2)]
    public decimal Depth { get; set; }


    // associations
    [JsonIgnore]
    public IList<Product>? Products { get; set; }

}