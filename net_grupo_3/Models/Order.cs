namespace net_grupo_3.Models;

[Table("order")]
public class Order
{
    // attributes
    [Key,
    Column("id")]
    public int Id { get; set; }

    [Column("order_time")]
    public DateTime? OrderTime { get; set; }
    [Column("delivery_time")]
    public DateTime? DeliveryTime { get; set; }

    // relationships
    [JsonIgnore]
    public User? User { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }
    // foreign keys (FK)
    public int? UserId { get; set; }
    //public int? StoreID  { get; set; }
}
