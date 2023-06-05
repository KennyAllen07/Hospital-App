using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class PrescriptionsRepository : GenericRepository<Prescriptions>, IPrescriptionsRepository
    {
        public PrescriptionsRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Prescriptions>> GetPrescriptionsByDoctorId(int DoctorId)
        {
            return await _Context.Prescriptions
            .Include(prescript => prescript.Prescription)
            .Where(x => x.IsDeleted == false && x.DoctorId == DoctorId)
            .ToListAsync();
        }

        public async Task<IList<Prescriptions>> GetPrescriptionsByPatientId(int PatientId)
        {
            return await _Context.Prescriptions
            .Include(prescript => prescript.Prescription)
            .Where(x => x.IsDeleted == false && x.PatientId == PatientId)
            .ToListAsync();
        }

       
    }
}
