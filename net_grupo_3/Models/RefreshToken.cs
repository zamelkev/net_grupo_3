namespace net_grupo_3.Models
{
    [Index(nameof(UserId), IsUnique = true)]
    [Index(nameof(Token), IsUnique = true)]
    [Table("refresh_token")]
    public class RefreshToken
    {
        [Key, Column("id", Order = 0)]
        public int Id { get; set; }

        [Column("token", Order = 1)]
        public string Token { get; set; }

        [Column("created", Order = 2)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Column("expires", Order = 3)]
        public DateTime Expires { get; set; } = DateTime.Now.AddMonths(6);

        // relationships
        public User? User { get; set; }

        // foreign keys
        public int? UserId { get; set; }
    }
}