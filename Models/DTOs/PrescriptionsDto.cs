using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
    public class CreatePrescriptionsDto
    {
        
      
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
    }
    public class UpdatePrescriptionsDto
    {
        
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
    }
    public class GetPrescriptionsDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
    }
}
