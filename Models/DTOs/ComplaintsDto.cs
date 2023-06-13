using Hospital_App.Entities;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Models.DTOs
{
    public class CreateComplaintsDto
    {
        public string Name { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
    }
    public class UpdateComplaintsDto
    {
        public int PatientId { get; set; }
        public string Description { get; set; }

    }
    public class GetComplaintsDto
    {
        public string Name { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }
}
