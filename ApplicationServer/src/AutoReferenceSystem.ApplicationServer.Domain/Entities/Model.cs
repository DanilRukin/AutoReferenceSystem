using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Models")]
    public class Model
    {
        //[Column("id_model")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<ReferensingQuery>? ReferensingQueries { get; set; } = new List<ReferensingQuery>();

        public ICollection<ModelCharacteristic>? ModelCharacteristics { get; set; } = new List<ModelCharacteristic>();

        public Server? Server { get; set; }

        //[Column("id_server")]
        public int? ServerId { get; set; }
    }
}
