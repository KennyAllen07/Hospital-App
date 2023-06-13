using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Events : AuditableEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public DateTime Date { get; set; }
    }
}
