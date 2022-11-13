namespace net_grupo_3.Models;

[Table("container")]
public class Container
{
    [Key,
    Column("id")]  
    public int Id { get; set; }

    [Column("volume")]
    public double? Volume { get; set; }

    [Column("height")]
    public double Height { get; set; }

    [Column("width")]
    public double Width { get; set; }

    [Column("depth")]
    public double Depth { get; set; }

    // associations
    public IList<Product> Products { get; set; }

}
