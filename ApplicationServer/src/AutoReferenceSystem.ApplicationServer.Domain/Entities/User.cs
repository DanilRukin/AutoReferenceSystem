using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Column("user_id")]
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("first_name")]
        [MaxLength(250)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        [MaxLength(250)]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Column("patronymic")]
        [MaxLength(250)]
        public string? Patronymic { get; set; } = string.Empty;

        [Column("login")]
        [MaxLength(250)]
        [Required]
        public string Login { get; set; } = string.Empty;

        [Column("password")]
        [MaxLength(250)]
        [Required]
        public string Password { get; set; }

        public IEnumerable<Session> Sessions { get; set; } = Enumerable.Empty<Session>();
    }
}
