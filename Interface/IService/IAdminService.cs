using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IAdminService
    {
        Task<BaseResponse> AddAdmin(CreateAdminDto admin);
        Task<BaseResponse> UpdateAdmin(int id, UpdateAdminDto admin);
        Task<BaseResponse> DeleteAdmin(int Id);
        Task<AdminResponse> GetAllAdmins();
        
        Task<BaseResponse> GetAdminById(int id);
    }
}
