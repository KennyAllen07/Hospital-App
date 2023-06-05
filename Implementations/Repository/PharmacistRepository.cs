using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class PharmacistRepository : GenericRepository<Pharmacist>, IPharmacistRepository
    {
        public PharmacistRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Pharmacist>> GetPharmacistById(int PharmacistId)
        {
            return await _Context.Pharmacists
            .Include(Pharmacist => Pharmacist.Id)
            .Where(x => x.IsDeleted == false && x.Id == PharmacistId)
            .ToListAsync();
        }

        public async Task<IList<Pharmacist>> GetPharmacistByName(string PharmacistName)
        {
            return await _Context.Pharmacists
           .Include(Pharmacist => Pharmacist.Id)
           .Where(x => x.IsDeleted == false && x.User.FirstName == PharmacistName)
           .ToListAsync();
        }
    }
}
