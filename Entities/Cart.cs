using Hospital_App.Contracts;
using Hospital_App.Entities.Enums;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Entities
{
    public class Cart : AuditableEntity
    {
        public string ReferenceId { get; set; }
        public int DrugId { get; set; }
        public int PatientId { get; set; }
        public int Quantity { get; set; }
        public IsPaid IsPaid { get; set; }
        public double Price { get; set; }
        public AddCart AddToCart { get; set; }
        
    }
}
