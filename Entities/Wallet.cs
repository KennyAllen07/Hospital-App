using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Wallet : AuditableEntity
    {
        public decimal Amount { get; set; }
        public int PatientId { get; set; }
        public string? AccountNumber { get; set; }
        public string? Bank { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PIN { get; set; }
    }
}
