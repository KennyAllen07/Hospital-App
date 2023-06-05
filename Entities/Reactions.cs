using Hospital_App.Contracts;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Reactions : AuditableEntity
    {
        public int ReactionsCount { get; set; }
        public string ReactionsName { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
