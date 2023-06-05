namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class ComplaintsResponse : BaseResponse
    {
        public List<GetComplaintsDto> Data { get; set; } = new List<GetComplaintsDto>();
    }
    public class SingleComplaintResponse : BaseResponse
    {
        public GetComplaintsDto Data { get; set; } = new GetComplaintsDto();
    }
}
