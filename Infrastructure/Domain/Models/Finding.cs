using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneR2.Infrastructure.Domain.Models
{
    public class Finding
    {
        public Guid? ID { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public Guid? ConsultationRecordID { get; set; }

        [ForeignKey("ConsultationRecordID")]
        public ConsultationRecord? Consultation { get; set; }
    }
}
