using Hospital_App.Contracts;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Cart : AuditableEntity
    {
        public List<Order> Order { get; set; }
        public int PatientId { get; set; }
    }
}
