using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IPrescriptionsService
    {
        Task<BaseResponse> AddPrescription(CreatePrescriptionsDto createPrescriptions);
        Task<BaseResponse> UpdatePrescription(UpdatePrescriptionsDto updatePrescriptions);
        Task<BaseResponse> DeletePrescription(int Id);
        Task<BaseResponse> GetPrescription(int Id);
        Task<PrescriptionsResponse> GetPrescriptions();
    }
}
