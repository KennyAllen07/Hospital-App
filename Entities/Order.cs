using Hospital_App.Contracts;

namespace Hospital_App.Entities
{
    public class Order : AuditableEntity
    {
        public string OrderSecretId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DrugId { get; set; }
        public Drugs Drugs { get; set; }

    }
}
