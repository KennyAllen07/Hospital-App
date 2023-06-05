using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
    public class CreateWalletDto
    {
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
    }
    public class UpdateWalletDto
    {
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
    }
    public class GetWalletDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }
}
