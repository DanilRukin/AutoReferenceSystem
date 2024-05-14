﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Models")]
    public class Model
    {
        [Column("id_model")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<ReferensingQuery> ReferensingQueries { get; set; } = Enumerable.Empty<ReferensingQuery>();

        public IEnumerable<ModelCharacteristic> ModelCharacteristics { get; set; } = Enumerable.Empty<ModelCharacteristic>();
    }
}
