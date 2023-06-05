using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Address : AuditableEntity
    {

        public int NumberLine { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
