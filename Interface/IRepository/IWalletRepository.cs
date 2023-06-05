using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.Repository;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Hospital_App.Interfaces.IRepository
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        Task<Wallet> GetWallet(int id);
    }
}
