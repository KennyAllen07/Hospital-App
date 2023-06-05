namespace Hospital_App.Contracts
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
        int? DeletedBy { get; set; }
        bool? IsDeleted { get; set; }
    }
}
