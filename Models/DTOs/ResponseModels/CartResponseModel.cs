namespace Hospital_App.Models.DTOs.ResponseModels
{
   
        public class CartResponse : BaseResponse
        {
            public List<GetCartDto> Data { get; set; } = new List<GetCartDto>();
        }
        public class SingleCartResponse : BaseResponse
        {
            public GetCartDto Data { get; set; } = new GetCartDto();
        }
    
}
