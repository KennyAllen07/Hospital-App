using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {

        Task<IList<Patient>> GetPatientByName(string Firstname);
        Task<IList<Patient>> GetPatients();
        Task<Patient> GetPatient(int Id);
    }
}
