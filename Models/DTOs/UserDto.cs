using Hospital_App.Entities;
using Hospital_App.Entities.Enums;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Models.DTOs
{
    public class CreateUserDto
    {
            
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Gender Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public IFormFile? Picture { get; set; }
            public string PhoneNumber { get; set; }
            public string NextOfKin { get; set; }
            public int PostalCode { get; set; }
            public int NumberLine { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public Patient Patient { get; set; }
            public Admin Admin { get; set; }
            public Doctor Doctor { get; set; }
            public Pharmacist Pharmacist { get; set; }
            public List<UserRoleDto> Roles { get; set; }

    }
    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile? Picture { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }
        public int PostalCode { get; set; }
        public int NumberLine { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Picture { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }
        public int PostalCode { get; set; }
        public int NumberLine { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public GetRoleDto Role { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }
    public class Delete
    {
        public int Id { get; set; }
    }



}
