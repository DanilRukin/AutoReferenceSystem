﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("ListValuesCharacteristics")]
    public class ListValuesCharacteristic
    {
        [Column("id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Characteristic Characteristic { get; set; }

        [Column("id_characteristics")]
        [Required]
        public int CharacteristicId { get; set; }

        [Column("value")]
        public string? Value { get; set; } = string.Empty;
    }
}
