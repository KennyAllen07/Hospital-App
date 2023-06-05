using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Patient>> GetPatientByName(string Firstname)
        {
            return await _Context.Patients
            .Include(patient => patient.User).Where(x => x.IsDeleted == false && x.User.FirstName == Firstname)
            .ToListAsync();
        }
        public async Task<Patient> GetPatient(int Id)
        {
            return await _Context.Patients.Include(x => x.User).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<IList<Patient>> GetDoctors()
        {
            return await _Context.Patients
            .Include(patient => patient.User).Where(x => x.IsDeleted == false)
            .ToListAsync();
        }

        public async Task<IList<Patient>> GetPatients()
        {
            
           return await _Context.Patients
           .Include(patient => patient.User).Where(x => x.IsDeleted == false)
           .ToListAsync();
            
        }
    }
}
