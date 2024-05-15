using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("CharacteristicsTypes")]
    public class CharacteristicsType
    {
        [Column("id_characteristics_type")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Characteristic> Characteristics { get; set; } = Enumerable.Empty<Characteristic>();
    }
}
