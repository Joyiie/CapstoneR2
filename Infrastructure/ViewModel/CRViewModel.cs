namespace CapstoneR2.Infrastructure.ViewModel
{
    public class CRViewModel
    {
        public Guid? ConsultationRecordID { get; set; }
        public Guid? PatientID { get; set; }
        public string? Symptoms { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid? FindingID { get; set; }
        public string? FTags { get; set; }
        public string? FDescription { get; set; }
        public Guid? PrescriptionID { get; set; }
        public string? PTags { get; set; }
        public string? PDescription { get; set; }
    }
}
