namespace net_grupo_3.Models;

[Table("Shop")]
public class Shop
{
    [Key, Column("Id")]
    public int Id { get; set; }

    [Required, Column("Name")]
    public string Name { get; set; }
}

