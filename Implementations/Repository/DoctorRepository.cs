using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Doctor>> GetDoctorByName(string LastName)
        {
            return await _Context.Doctors
            .Include(doctor => doctor.User).Where(x => x.IsDeleted == false && x.User.LastName == LastName)
            .ToListAsync();
        }
        public async Task<Doctor> GetDoctor(int Id)
        {
            return await _Context.Doctors.Include(x => x.User).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<IList<Doctor>> GetDoctors()
        {
            return await _Context.Doctors
            .Include(doctor => doctor.User).Where(x => x.IsDeleted == false)
            .ToListAsync();
        }

    }
}
