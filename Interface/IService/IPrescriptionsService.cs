using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IPrescriptionsService
    {
        Task<BaseResponse> AddPrescription(CreatePrescriptionsDto createPrescriptions, int DoctorId, int PatientId);
        Task<BaseResponse> UpdatePrescription(UpdatePrescriptionsDto updatePrescriptions, int DoctorId, int id);
        Task<BaseResponse> DeletePrescription(int Id);
        Task<BaseResponse> GetPrescription(int Id);
        Task<PrescriptionsResponse> GetPrescriptions();
    }
}
