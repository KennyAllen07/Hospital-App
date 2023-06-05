namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class DoctorResponse : BaseResponse
    {
        public List<GetDoctorDto> Data { get; set; } = new List<GetDoctorDto>();
    }
    public class SingleDoctorResponse : BaseResponse
    {
        public GetDoctorDto Data { get; set; } = new GetDoctorDto();
    }
}
