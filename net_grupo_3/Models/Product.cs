namespace net_grupo_3.Models;

[Table("product")]
public class Product {
    // atributos
    [Key, 
    Column("id")]
    public int Id { get; set; }

    [Required,
    Column("name")]
    public string Name { get; set; }

    [Required,
    Column("Cost")]
    public Double Cost { get; set; }

    [Required,
    Column("price")]
    public Double Price { get; set; }

    [Required,
    Column("stock")]
    public int Stock { get; set; }

    [Required,
    Column("tax")]
    public Double Tax { get; set; }

    [Required,
    Column("date")]
    public DateTime ReleaseDate { get; set; }

    [Required,
    Column("comment")]
    ProductComment comment { get; set; }



    public Product(int id, string name, double cost, double price, int stock, double tax, DateTime releaseDate, ProductComment comment) {
        Id = id;
        Name = name;
        Cost = cost;
        Price = price;
        Stock = stock;
        Tax = tax;
        ReleaseDate = releaseDate;
        this.comment = comment;
    }
}
