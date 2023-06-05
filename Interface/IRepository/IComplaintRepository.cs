using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IComplaintRepository : IGenericRepository<Complaints>
    {
        Task<IList<Complaints>> GetComplaintsByDateAdded(DateTime dateAdded);
        Task<IList<Complaints>> GetComplaintsByPatientId(int PatientId);
        Task<IList<Complaints>> GetComplaintsBetweenDates(DateTime startingDate, DateTime endingDate);
        Task<IList<Complaints>> GetComplaintsByMonth(DateTime month);
        Task<IList<Complaints>> GetComplaintsByYear(DateTime year);
    }
}
