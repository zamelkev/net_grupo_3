namespace net_grupo_3.Models;

[Table("order_detail")]
public class OrderDetail
{
    // attributes
    [Key,
    Column("id")]
    public int Id { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    // relationships
    [JsonIgnore]
    public Order? Order { get; set; }
    public Product? Product { get; set; }
    // foreign keys (FK)
    public int? ProductId { get; set; }
    public int? OrderId { get; set; }
}
