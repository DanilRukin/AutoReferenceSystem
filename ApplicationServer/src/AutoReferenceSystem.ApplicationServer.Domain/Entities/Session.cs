using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoReferenceSystem.ApplicationServer.Domain.Entities
{
    [Table("Sessions")]
    public class Session
    {
        //[Column("id_session")]
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        public User User { get; set; }

        [Required]
        //[Column("user_id")]
        public Guid UserId { get; set; }

        //[Column("begin_date")]
        [Required]
        public DateTime BeginDate { get; set; }

        //[Column("end_date")]
        public DateTime? EndDate { get; set; }

        public ICollection<ReferensingQuery>? ReferensingQueries { get; set; } = new List<ReferensingQuery>();
    }
}
