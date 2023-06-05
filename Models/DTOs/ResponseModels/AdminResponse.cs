namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class AdminResponse : BaseResponse
    {
        public List<GetAdminDto> Data { get; set; } = new List<GetAdminDto>();
    }
    public class SingleAdminResponse : BaseResponse
    {
        public GetAdminDto Data { get; set; } = new GetAdminDto();
    }
}
