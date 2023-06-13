using Hospital_App.Models.DTOs.ResponseModels;
using Hospital_App.Models.DTOs;

namespace Hospital_App.Interface.IService
{
    public interface IBioDataService
    {
        Task<BaseResponse> AddBiodata(CreateBioDataDto createBioData);
        Task<BaseResponse> UpdateBioData(UpdateBioDataDto updateBioData, int id);
        Task<BaseResponse> DeleteBioData(int id);
        Task<BaseResponse> GetBioDataByPatientId(int Patientid);
        Task<BioDataResponse> GetAllBioData();
    }
}
