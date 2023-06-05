using Hospital_App.Contracts;
using Hospital_App.Entities.Enums;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Pharmacist : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
