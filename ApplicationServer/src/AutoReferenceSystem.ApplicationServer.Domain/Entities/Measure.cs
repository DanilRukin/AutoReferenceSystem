using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Measures")]
    public class Measure
    {
        //[Column("measure_id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        //[Column("name")]
        [Required]
        [MaxLength(100)]
        public  string Name { get; set; } = string.Empty;

        public ICollection<Characteristic> Characteristics { get; set; } = new List<Characteristic>();
    }
}
