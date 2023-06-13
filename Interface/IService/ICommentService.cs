using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface ICommentService
    {
        Task<BaseResponse> AddComment(CreateCommentDto createComment);
        Task<BaseResponse> DeleteComment(int CommentId);
        Task<CommentResponse> GetCommentPyPostId(int PostId);
        Task<BaseResponse> GetComment(int commentId);
        
       

    }
}
