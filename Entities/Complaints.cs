using Hospital_App.Contracts;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Complaints : AuditableEntity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
        
        
    }
}
