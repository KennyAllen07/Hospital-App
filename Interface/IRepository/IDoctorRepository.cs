using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<IList<Doctor>> GetDoctorByName(string LastName);
        Task<IList<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int Id);
    }
}
