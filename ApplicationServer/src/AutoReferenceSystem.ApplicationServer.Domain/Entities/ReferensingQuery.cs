using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("ReferencingQueries")]
    public class ReferensingQuery
    {
        [Column("id_query")]
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("query_number")]
        [Required]
        public int QueryNumber { get; set; }

        public Session Session { get; set; }

        [Column("id_session")]
        [Required]
        public Guid SessionId { get; set; }

        public Model Model { get; set; }

        [Column("id_model")]
        [Required]
        public int ModelId { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; } = Enumerable.Empty<Attachment>();

        public IEnumerable<ReferencingQueryCharacteristic> ReferencingQueryCharacteristics { get; set; } = Enumerable.Empty<ReferencingQueryCharacteristic>();
    }
}
