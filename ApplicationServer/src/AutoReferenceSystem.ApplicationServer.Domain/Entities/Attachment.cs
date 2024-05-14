using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Attachments")]
    public class Attachment
    {
        [Column("id_attachment")]
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("creation_date")]
        [Required]
        public DateTime CreationDate { get; set; }

        [Column("attachment_size_in_bytes")]
        public long? AttachmentSizeInBytes { get; set; }

        public AttachmentType AttachmentType { get; set; }

        [Column("id_attachment_type")]
        [Required]
        public int AttachmentTypeId { get; set; }

        [Column("path")]
        public string Path { get; set; } = string.Empty;

        public ReferensingQuery ReferensingQuery { get; set; }

        [Column("id_query")]
        [Required]
        public Guid ReferensingQueryId { get; set; }
    }
}
