using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Posts : AuditableEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public Comment Comment { get; set; }
    }
}
