using Hospital_App.Contracts;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Diagnostics.Contracts;

namespace Hospital_App.Entities
{
    public class Transaction : AuditableEntity
    {
        public string ReferenceNo { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string TransactionDescription { get; set; } 
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public double Amount { get; set; }
        public double ShippingFees { get; set; }
        public double TransactionFees { get; set; }
    }
}
