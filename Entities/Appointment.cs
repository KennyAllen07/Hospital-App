using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Appointment : AuditableEntity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
    }
}
