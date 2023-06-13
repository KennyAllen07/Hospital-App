namespace Hospital_App.Models.DTOs.ResponseModels
{
    
        public class PostResponse : BaseResponse
        {
            public List<GetPostDto> Data { get; set; } = new List<GetPostDto>();
        }
        public class SinglePostResponse : BaseResponse
        {
            public GetPostDto Data { get; set; } = new GetPostDto();
        }
   
}
