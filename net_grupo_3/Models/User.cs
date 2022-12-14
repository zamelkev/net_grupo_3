

namespace net_grupo_3.Models;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(UserName), IsUnique = true)]
[Table("user")]
public class User
{
    // atributos
    [Key, Column("id", Order = 0)]
    public int Id { get; set; }
    [Column("full_name", TypeName = "varchar(75)", Order = 2)]
    public string? FullName { get; set; }
    [Required, Column("username")]
    public string? UserName { get; set; }
    [Required, Column("email")]
    public string? Email { get; set; }
    [Required, Column("password")]
    public string? Password { get; set; }
    [Column("role")]
    public int? Role { get; set; }
    [Column("address")]
    public string? Address { get; set; }
    [Column("country")]
    public string? Country { get; set; }
    [Column("locality")]
    public string? Locality { get; set; }
}
