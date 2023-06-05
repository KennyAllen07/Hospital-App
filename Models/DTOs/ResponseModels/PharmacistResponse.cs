namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class PharmacistResponse : BaseResponse
    {
        public List<GetPharmacistDto> Data { get; set;} = new List<GetPharmacistDto>();
    }
    public class SinglePharmacistResponse : BaseResponse
    {
        public GetPharmacistDto Data { get; set; } = new GetPharmacistDto();
    }
}
