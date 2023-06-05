namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class AppointmentResponse : BaseResponse
    {
        public List<GetAppointmentDto> Data { get; set; } = new List<GetAppointmentDto>();
    }
    public class SingleAppointmentResponse : BaseResponse
    {
        public GetAppointmentDto Data { get; set; } = new GetAppointmentDto();
    }
}
