using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interface.IRepository
{
    public interface IBioDataRepository : IGenericRepository<BioData>
    {
        Task<BioData> GetBioDataByPatientId(int patientId); 
    }
}
