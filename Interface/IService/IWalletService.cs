using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IWalletService
    {

        Task<BaseResponse> CreditWallet(UpdateWalletDto updateWallet, int walletId);
        Task<BaseResponse> DeleteWallet(int Id);
        Task<BaseResponse> GetWallet(int Id);
    }
}
