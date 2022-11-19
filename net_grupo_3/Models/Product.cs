namespace net_grupo_3.Models;

[Table("product")]
public class Product {
    // atributos
    [Key, 
    Column("id")]
    public int Id { get; set; }

    [
    Column("name")]
    public string? Name { get; set; }

    [ 
    Column("Cost")]
    public Double Cost { get; set; }

    [ 
    Column("price")]
    public Double Price { get; set; }

    [ 
    Column("stock")]
    public int Stock { get; set; }

    [ 
    Column("tax")]
    public Double Tax { get; set; }



    // nuevas propiedades
    [Column("cpu")]
    public string? CPU { get; set; }

    [Column("ram")]
    public string? Ram { get; set; }

    [Column("graphiccard")]
    public string? GraphicCard { get; set; }


    [ 
    Column("date")]
    public DateTime ReleaseDate { get; set; }

    
    // associations

    public ICollection<ProductComment>? ProductComments { get; set; }
    public Container? Container { get; set; }
    public IList<Order>? Orders { get; set; }


    public Manufacturer? Manufacturer { get; set; }
    
    public Category? Category { get; set; }
    // foreign key
    
    public int? ManufacturerId { get; set; }

    public int? CategoryId { get; set; }

    public int? ContainerId { get; set; }





}
