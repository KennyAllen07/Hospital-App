namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class TransactionResponse : BaseResponse
    {
        public List<GetTransactionDto> Data { get; set; } = new List<GetTransactionDto>();
    }
    public class SingleTransactionResponse : BaseResponse
    {
        public GetTransactionDto Data { get; set; } = new GetTransactionDto();
    }
}
