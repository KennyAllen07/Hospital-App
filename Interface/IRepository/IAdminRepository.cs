using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetAdmin(int Id);
        Task<IList<Admin>> GetAllAdminsAsync();
    }
}
