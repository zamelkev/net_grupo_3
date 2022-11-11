

namespace net_grupo_3.Models;

[Table("client")]
public class Client
{

    // atributos
    [Key, Column("id_client", Order = 0)]
    public int Id { get; set; }

    [Column("client_name", TypeName = "varchar(75)", Order = 2)]
    public string ClientName { get; set; }


}
