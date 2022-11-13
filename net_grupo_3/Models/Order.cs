namespace net_grupo_3.Models;

[Table("order")]
public class Order
{
    // attributes
    [Key,
    Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    public DateTime? OrderDate { get; set; }

    // relationships
    public Client? Client { get; set; }
    //public Store? Store { get; set; }

    // foreign keys (FK)
    public int? ClientId { get; set; }
    //public int? StoreID  { get; set; }

    /*
     * OrderDate (DateTime)
Relationships
Client
Store
FKs
ClientId
StoreId
     */
}
