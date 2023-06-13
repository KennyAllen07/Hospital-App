using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class EventRepository : GenericRepository<Events>, IEventRepository
    {
        public EventRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Events>> GetEventsByDoctorId(int doctorId)
        {
            return await _Context.Events.Include(x => x.Doctor).ThenInclude(x => x.User).Where(x => x.DoctorId == doctorId).ToListAsync();
        }

        public async Task<IList<Events>> SortEventsByDateAdded(DateTime date)
        {
            return await _Context.Events.Include(x => x.Doctor).OrderByDescending(x => x.Date == date).ToListAsync();
        }
    }
}
