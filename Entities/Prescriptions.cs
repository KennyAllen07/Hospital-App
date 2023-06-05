using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Prescriptions : AuditableEntity
    {
        public int ComplaintsId { get; set; }
        public Complaints Complaints { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        
    }
}
