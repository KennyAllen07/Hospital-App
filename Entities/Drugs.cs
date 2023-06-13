using Hospital_App.Contracts;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Drugs : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}
