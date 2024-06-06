using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Characteristics")]
    public class Characteristic
    {
        //[Column("id_characteristics")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Column("name")]
        [MaxLength(128)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public CharacteristicsType CharacteristicType { get; set; }

        //[Column("id_characteristics_type")]
        [Required]
        public int CharacteristicTypeId { get; set; }

        public Measure Measure { get; set; }

        //[Column("id_measure")]
        [Required]
        public int MeasureId { get; set; }

        public ICollection<ListValuesCharacteristic> ListValuesCharacteristics { get; set; } = new List<ListValuesCharacteristic>();

        public ICollection<ModelCharacteristic> ModelCharacteristics { get; set; } = new List<ModelCharacteristic>();

        public ICollection<ReferencingQueryCharacteristic> ReferencingQueryCharacteristics { get; set; } = new List<ReferencingQueryCharacteristic>();

    }
}
