namespace Hospital_App.Models.DTOs.ResponseModels
{
   
        public class CommentResponse : BaseResponse
        {
            public List<GetCommentDto> Data { get; set; } = new List<GetCommentDto>();
        }
        public class SingleCommentResponse : BaseResponse
        {
            public GetCommentDto Data { get; set; } = new GetCommentDto();
        }
    
}
