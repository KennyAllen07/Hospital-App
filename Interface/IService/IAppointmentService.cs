using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IAppointmentService
    {
        Task<BaseResponse> AddAppointment(CreateAppointmentDto createAppointment);
        Task<BaseResponse> UpdateAppointment(int id, UpdateAppointmentDto updateAppointment);
        Task<BaseResponse> DeleteAppointment(int id);
        Task<BaseResponse> GetAppointment(int id);
        Task<AppointmentResponse> GetAllAppointments(int PatientId);
        Task<AppointmentResponse> GetAllAppointments();
    }
}
