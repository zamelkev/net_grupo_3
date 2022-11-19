namespace net_grupo_3.Models;

[Table("order")]
public class Order
{
    // attributes
    [Key,
    Column("id")]
    public int Id { get; set; }

    [Column("order_date")]
    public DateTime? OrderDate { get; set; }

    // relationships
    public User? User { get; set; }
    public IList<Product>? Products { get; set; }
    // foreign keys (FK)
    public int? UserId { get; set; }
    //public int? StoreID  { get; set; }
}
