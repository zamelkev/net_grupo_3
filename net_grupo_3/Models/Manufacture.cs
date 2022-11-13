namespace net_grupo_3.Models;


[Table("Manufacture")]
public class Manufacture
{
    [Key, Column("id")]
    public int Id { get; set; }

    [Required, Column("name")]
    public string Name { get; set; }
}
