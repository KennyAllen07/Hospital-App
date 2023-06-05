using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class BioDataRepository : GenericRepository<BioData>, IBioDataRepository
    {
        public BioDataRepository(HospitalApplicationContext Context) 
        {
            _Context= Context;
        }

        public async Task<BioData> GetBioDataByPatientId(int patientId)
        {
            return await _Context.BioData
            .FirstOrDefaultAsync(x => x.PatientId == patientId);
        }
    }
}
