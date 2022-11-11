

namespace net_grupo_3.Models;

[Table("categories")]
public class Category
{

    // atributos
    [Key, Column("id_category", Order = 0)]
    public int Id { get; set; }

    [Column("category_name", TypeName = "varchar(75)", Order = 2)]
    public string CategoryName { get; set; }


}
