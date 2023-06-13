using Hospital_App.Contracts;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Comment : AuditableEntity
    {
        public int PostId { get; set; }
        public Posts Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Comments { get; set; }  
        public DateTime Date { get; set; }
    }
}
