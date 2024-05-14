using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Characteristics")]
    public class Characteristic
    {
        [Column("id_characteristics")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(128)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public CharacteristicsType CharacteristicType { get; set; }

        [Column("id_characteristics_type")]
        [Required]
        public int CharacteristicTypeId { get; set; }

        public Measure Measure { get; set; }

        [Column("id_measure")]
        [Required]
        public int MeasureId { get; set; }

        public IEnumerable<ListValuesCharacteristic> ListValuesCharacteristics { get; set; } = Enumerable.Empty<ListValuesCharacteristic>();

        public IEnumerable<ModelCharacteristic> ModelCharacteristics { get; set; } = Enumerable.Empty<ModelCharacteristic>();

        public IEnumerable<ReferencingQueryCharacteristic> ReferencingQueryCharacteristics { get; set; } = Enumerable.Empty<ReferencingQueryCharacteristic>();

    }
}
