using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interface.IRepository
{
    public interface IEventRepository : IGenericRepository<Events>
    {
        Task<IList<Events>> SortEventsByDateAdded(DateTime date);
        Task<IList<Events>> GetEventsByDoctorId(int doctorId);
    }
}
