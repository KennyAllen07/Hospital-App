namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class WalletResponse : BaseResponse
    {
        public List<GetWalletDto> Data { get; set; } = new List<GetWalletDto>();
    }
    public class SingleWalletResponse : BaseResponse
    {
        public GetWalletDto Data { get; set; } = new GetWalletDto();
    }
}
