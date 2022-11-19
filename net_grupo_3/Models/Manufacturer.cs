namespace net_grupo_3.Models;


[Table("manufacturer")]
public class Manufacturer
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("foundation_date")]
    public DateTime? FoundationDate { get; set; }

    /*
    [Column("Location")]
    public string Location { get; set; }
    */

    /*
    [Column("Contact")]
    public string Contact { get; set; }
    */

    [JsonIgnore]
    public IList<Product>? Products { get; set; }








}
