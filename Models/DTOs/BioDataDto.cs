using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
   
        public class CreateBioDataDto
        {
            
            public int PatientId { get; set; }
            public double Weight { get; set; }
            public double Height { get; set; }
            public string BloodType { get; set; }
            public string Genotype { get; set; }
    }
        public class UpdateBioDataDto
        {
            
            public double Weight { get; set; }
            public double Height { get; set; }
            public string BloodType { get; set; }
            public string Genotype { get; set; }

    }
        public class GetBioDataDto
        {
            public int Id { get; set; }
            public int PatientId { get; set; }
            public double Weight { get; set; }
            public double Height { get; set; }
            public string BloodType { get; set; }
            public string Genotype { get; set; }
    }
    
}
