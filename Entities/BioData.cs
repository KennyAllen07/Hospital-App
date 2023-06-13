using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class BioData : AuditableEntity
    {
        public int PatientId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string BloodType { get; set; }
        public string Genotype { get; set; }    

    }
}
