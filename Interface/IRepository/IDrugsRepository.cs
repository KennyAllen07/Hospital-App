using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IDrugsRepository : IGenericRepository<Drugs>
    {
        Task<IList<Drugs>> SortDrugsByDateAddedAsync(DateTime dateAdded);
        Task<IList<Drugs>> SortDrugsByDateUpdatedAsync(DateTime dateUpdated);
        Task<IList<Drugs>> SortDrugsByPrice(decimal price);
        Task<IList<Drugs>> SortDrugsByName(string name);
        Task<IList<Drugs>> SortDrugsByMonth(DateTime month);
        Task<IList<Drugs>> SortDrugsByYear(DateTime year);
    }
}
