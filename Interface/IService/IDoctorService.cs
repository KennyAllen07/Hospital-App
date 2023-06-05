using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IDoctorService
    {
        Task<BaseResponse> AddDoctor(CreateDoctorDto createDoctor);
        Task<BaseResponse> UpdateDoctor(int id, UpdateDoctorDto updateDoctor);
        Task<BaseResponse> DeleteDoctor(int id);
        Task<BaseResponse> GetDoctor(int id);
        Task<DoctorResponse> GetAllDoctors();
        Task<DoctorResponse> GetAllDoctorsByName(string name);
    }
}
