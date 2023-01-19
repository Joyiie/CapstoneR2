using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneR2.Infrastructure.Domain.Models
{
    public class Appointment
    {
        public Guid? ID { get; set; }
        public DateTime? StartTime { get; set;}
        public DateTime? EndTime { get; set;}
        public string? Description { get; set; }
        public Guid? PatientID { get; set; }

        [ForeignKey("PatientID")]
        public Patient? Patient{ get; set; }



    }
}
