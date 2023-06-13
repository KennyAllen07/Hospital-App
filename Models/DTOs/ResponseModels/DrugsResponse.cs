namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class DrugsResponse : BaseResponse
    {
        public List<GetDrugsDto> Data { get; set; } = new List<GetDrugsDto>();
    }
    public class SingleDrugsResponse : BaseResponse
    {
        public GetDrugsDto Data { get; set; } = new GetDrugsDto();
    }
}
