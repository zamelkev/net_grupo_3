

namespace net_grupo_3.Models;

[Index(nameof(Slug), IsUnique = true)]
[Table("categories")]
public class Category
{

    // atributos
    [Key, Column("id", Order = 0)]
    public int Id { get; set; }

    [Column("name", Order = 2)]
    public string? Name { get; set; }
    [Column("slug")]
    public string? Slug { get; set; }
    [Column("img_url")]
    public string? ImgUrl { get; set; }


}
