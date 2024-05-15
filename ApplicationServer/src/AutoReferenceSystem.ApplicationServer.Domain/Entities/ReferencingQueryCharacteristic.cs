using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("ReferencingQueryCharacteristics")]
    public class ReferencingQueryCharacteristic
    {
        public Characteristic Characteristic { get; set; }

        [Column("id_characteristics")]
        [Required]
        public int CharacteristicId { get; set; }

        public ReferensingQuery ReferensingQuery { get; set; }

        [Column("id_query")]
        [Required]
        public Guid ReferensingQueryId { get; set; }

        [Column("value")]
        [MaxLength(512)]
        public string? Value { get; set; } = string.Empty;
    }
}
