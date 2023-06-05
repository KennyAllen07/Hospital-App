namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class PrescriptionsResponse : BaseResponse
    {
        public List<GetPrescriptionsDto> Data { get; set; } = new List<GetPrescriptionsDto>();
    }
}
