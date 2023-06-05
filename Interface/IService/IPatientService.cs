using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IPatientService
    {
        Task<BaseResponse> AddPatient(CreatePatientDto createPatient);
        Task<BaseResponse> UpdatePatient(int id, UpdatePatientDto updatePatient);
        Task<BaseResponse> DeletePatient(int id);
        Task<BaseResponse> GetPatient(int id);
        Task<PatientResponse> GetAllPatients();
        Task<PatientResponse> GetPatientByName(string name);
    }
}
