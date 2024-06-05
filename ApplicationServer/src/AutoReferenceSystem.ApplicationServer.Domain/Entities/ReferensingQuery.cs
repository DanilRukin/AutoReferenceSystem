using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("ReferencingQueries")]
    public class ReferensingQuery
    {
        //[Column("id_query")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        //[Column("query_number")]
        [Required]
        public int QueryNumber { get; set; }

        public Session Session { get; set; }

        //[Column("id_session")]
        [Required]
        public Guid SessionId { get; set; }

        public Model Model { get; set; }

        //[Column("id_model")]
        [Required]
        public int ModelId { get; set; }

        public ICollection<Attachment>? Attachments { get; set; } = new List<Attachment>();

        public ICollection<ReferencingQueryCharacteristic>? ReferencingQueryCharacteristics { get; set; } = new List<ReferencingQueryCharacteristic>();
    }
}
