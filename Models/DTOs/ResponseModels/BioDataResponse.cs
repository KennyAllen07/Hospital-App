
namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class BioDataResponse : BaseResponse
    {
     public List<GetBioDataDto> Data { get; set; } = new List<GetBioDataDto>();
    }

    public class SingleBioDataResponse : BaseResponse
    {
        public GetBioDataDto Data { get; set; } = new GetBioDataDto();
        
    }
}
