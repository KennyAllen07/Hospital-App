namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class EventResponse : BaseResponse
    {
        public List<GetEventDto> Data { get; set; } = new List<GetEventDto>();
    }
    public class SingleEventResponse : BaseResponse
    {
        public GetEventDto Data { get; set; } = new GetEventDto();
    }
}
