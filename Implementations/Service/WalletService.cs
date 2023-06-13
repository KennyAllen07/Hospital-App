using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service
{
    public class WalletService : IWalletService
    {
        private readonly IPatientRepository _repository;
        private readonly IWalletRepository _walletRepository;
        public WalletService(IPatientRepository repository, IWalletRepository walletRepository)
        {
            _repository = repository;
            _walletRepository = walletRepository;
        }

        public async Task<BaseResponse> CreditWallet(UpdateWalletDto updateWallet, int walletId)
        {
            var wallet = await _walletRepository.GetAsync(x => x.Id == walletId);
            if(wallet == null)
            {
                return new BaseResponse
                {
                    Message = "You dont have a wallet",
                    Success= false,

                };
            }
            wallet.Amount = updateWallet.Amount;
            await _walletRepository.UpdateAsync(wallet);
            return new BaseResponse
            {
                Message = "You've Successfully Credited your Wallet",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteWallet(int Id)
        {
            var wallet = await _walletRepository.GetAsync(x => x.Id == Id);
            if(wallet == null)
            {
                return new BaseResponse
                {
                    Message = "Your Wallet doesn't exist",
                    Success = false,
                };
            }
            wallet.IsDeleted = true;
            await _walletRepository.UpdateAsync(wallet);
            return new BaseResponse
            {
                Message = "Your Wallet was deleted",
                Success = true,
            };
        }

        public async Task<BaseResponse> GetWallet(int Id)
        {
            var wallet = await _walletRepository.GetAsync(x => x.Id==Id);
            if(wallet == null)
            {
                return new BaseResponse
                {
                    Message = "Wallet Not Found",
                    Success = false,
                };
            }
            return new SingleWalletResponse
            {
                Data = new GetWalletDto()
                {
                    Amount= wallet.Amount,
                    Id= Id,
                    FirstName = wallet.FirstName,
                    LastName = wallet.LastName
                    

                }
            };

        }
    }
}
