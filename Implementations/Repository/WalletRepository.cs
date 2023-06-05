using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<Wallet> GetWallet(int id)
        {
            var wallet = await _Context.Wallets.SingleOrDefaultAsync(x => x.Id == id);
            return wallet;
        }

    }
}
