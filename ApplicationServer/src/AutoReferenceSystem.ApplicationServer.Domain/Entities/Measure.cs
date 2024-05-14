﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Measures")]
    public class Measure
    {
        [Column("measure_id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column("name")]
        [Required]
        [MaxLength(100)]
        public  string Name { get; set; } = string.Empty;

        public IEnumerable<Characteristic> Characteristics { get; set; } = Enumerable.Empty<Characteristic>();
    }
}
