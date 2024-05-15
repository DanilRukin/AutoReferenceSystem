using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("ModelCharacteristics")]
    public class ModelCharacteristic
    {
        public Model Model { get; set; }

        [Column("id_model")]
        [Required]
        public int ModelId { get; set; }

        public Characteristic Characteristic { get; set; }

        [Column("id_characteristics")]
        [Required]
        public int CharacteristicId { get; set; }

        [Column("value")]
        [MaxLength(512)]
        public string? Value { get; set; } = string.Empty;
    }
}
