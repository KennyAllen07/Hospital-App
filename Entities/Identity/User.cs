using Hospital_App.Contracts;
using Hospital_App.Entities.Enums;
namespace Hospital_App.Entities.Identity
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NextOfKin { get; set; }
        public Address Address { get; set; }
        public string? Picture { get; set; }
        public string PhoneNumber { get; set; }
        public Patient Patient { get; set; }
        public Admin Admin { get; set; }
        public Doctor Doctor { get; set; }
        public Pharmacist Pharmacist { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>(); 
    }
}
