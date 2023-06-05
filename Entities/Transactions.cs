using Hospital_App.Contracts;
using System.Diagnostics.Contracts;

namespace Hospital_App.Entities
{
    public class Transaction : AuditableEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DrugId { get; set; }
        public Drugs Drugs { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string TransactionDescription { get; set; } 
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
