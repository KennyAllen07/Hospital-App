using Hospital_App.Entities;
using Hospital_App.Entities.Enums;

namespace Hospital_App.Models.DTOs
{
    public class GetCartDto
    {
        public int PatientId { get; set; }
        public List<Cart> Items { get; set; }
        public IsPaid IsPaid { get; set; }
        public double Price { get; set; }

    }
}
