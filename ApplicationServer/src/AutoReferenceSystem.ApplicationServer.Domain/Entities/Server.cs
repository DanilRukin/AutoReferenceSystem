using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Servers")]
    public class Server
    {
        [Column("id_server")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column("address")]
        [Required]
        [MaxLength(128)]
        public string Address {  get; set; } = string.Empty;

        [Column("user")]
        [Required]
        [MaxLength(128)]
        public string User { get; set; } = string.Empty;

        [Column("user_password")]
        [Required]
        [MaxLength(128)]
        public string UserPassword { get; set; } = string.Empty;

        public IEnumerable<Model> Models { get; set; } = Enumerable.Empty<Model>();
    }
}
