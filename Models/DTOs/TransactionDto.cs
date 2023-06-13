using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
    public class CreateTransactionDto
    {
        public string ReferenceNo { get; set; }
        public int PatientId { get; set; }
        public string TransactionDescription { get; set; }
        public double Amount { get; set; }
        public double ShippingFees { get; set; }
        public double TransactionFees { get; set; }
    }
    public class GetTransactionDto
    { 
        public int Id { get; set;}
        public string ReferenceNo { get; set; }
        public int PatientId { get; set; }
        public List<Cart> Cart { get; set; }
        public string TransactionDescription { get; set; }
        public double Amount { get; set; }
        public double ShippingFees { get; set; }
        public double TransactionFees { get; set; }
    }

}
