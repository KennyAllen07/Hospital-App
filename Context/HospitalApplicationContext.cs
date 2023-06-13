using Microsoft.EntityFrameworkCore;
using Hospital_App.Entities.Identity;
using Hospital_App.Entities;
using Microsoft.Extensions.Options;

namespace Hospital_App.Context
{
    public class HospitalApplicationContext : DbContext
    {
        public HospitalApplicationContext(DbContextOptions<HospitalApplicationContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Complaints> Complaints { get; set; }
        public DbSet<Drugs> Drugs { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<BioData> BioData { get; set; }


    }
}
