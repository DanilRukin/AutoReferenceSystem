using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("AttachmentsTypes")]
    public class AttachmentType
    {
        [Column("id_attachment_type")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Attachment> Attachments { get; set; } = Enumerable.Empty<Attachment>();
    }
}
