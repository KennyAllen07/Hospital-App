namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class PatientResponse : BaseResponse
    {
        public List<GetPatientDto> Data { get; set; } = new List<GetPatientDto>(); 
        
    }
    public class SinglePatientResponse : BaseResponse
    {
        public GetPatientDto Data { get; set; } = new GetPatientDto();

    }
}
