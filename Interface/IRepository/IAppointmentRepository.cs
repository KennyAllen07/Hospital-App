using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IList<Appointment>> GetAppointmentsByDateAdded(DateTime dateAdded);
        Task<IList<Appointment>> GetAppointmentsByPatientId(int Id);
        Task<IList<Appointment>> GetAppointmentBetweenDates(DateTime startDate, DateTime endDate);
        Task<IList<Appointment>> GetAppointmentsByMonth(DateTime month);
        Task<IList<Appointment>> GetAppointmentsByYear(DateTime year);
    }
}
