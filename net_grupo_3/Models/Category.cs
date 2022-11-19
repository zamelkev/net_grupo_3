﻿

namespace net_grupo_3.Models;

[Table("categories")]
public class Category
{

    // atributos
    [Key, Column("id", Order = 0)]
    public int Id { get; set; }

    [Column("name", Order = 2)]
    public string? Name { get; set; }


}
