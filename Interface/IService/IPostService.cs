using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IPostService
    {
        Task<BaseResponse> AddPost(CreatePostDto createPost, int UserId);
        Task<BaseResponse> UpdatePost(UpdatePostDto updatePost);
        Task<BaseResponse> DeletePost(int id);
        Task<BaseResponse> GetPost(int id);
        Task<PostResponse> GetAllPosts();
        Task<PostResponse> GetAllPostsByUserId(int userId);
        Task<PostResponse> GetAllPostsByNoofLikes();
        Task<BaseResponse> AddLike(int userId, int postId);

    }
}
