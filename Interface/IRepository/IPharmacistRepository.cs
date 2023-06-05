using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IPharmacistRepository : IGenericRepository<Pharmacist>
    {
        Task<IList<Pharmacist>> GetPharmacistById(int PharmacistId);
        Task<IList<Pharmacist>> GetPharmacistByName(string PharmacistName);
    }
}
