using Hospital_App.Contracts;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Posts : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public Comment Comment { get; set; }
    }
}
