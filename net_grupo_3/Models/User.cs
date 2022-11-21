

namespace net_grupo_3.Models;

[Table("user")]
public class User
{
    // atributos
    [Key, Column("id", Order = 0)]
    public int Id { get; set; }
    [Column("full_name", TypeName = "varchar(75)", Order = 2)]
    public string? FullName { get; set; }
    [Column("username")]
    public string? UserName { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("password")]
    public string? Password { get; set; }
    [Column("role")]
    public int? Role { get; set; }
}
