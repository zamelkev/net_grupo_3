namespace net_grupo_3.Models;

[Table("order")]
public class Order
{
    // attributes
    [Key,
    Column("id")]
    public int Id { get; set; }

    [Column("description")]
    public string? Description { get; set; }
    [Column("order_date")]
    public DateTime? OrderDate { get; set; }

    // relationships
    public Client? Client { get; set; }
    //public Store? Store { get; set; }

    // foreign keys (FK)
    public int? ClientId { get; set; }
    //public int? StoreID  { get; set; }
}
