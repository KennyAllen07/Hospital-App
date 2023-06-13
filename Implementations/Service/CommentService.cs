using Hospital_App.Entities;
using Hospital_App.Interface.IRepository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service
{
    public class CommentService : ICommentService
    {
        
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        public async Task<BaseResponse> AddComment(CreateCommentDto createComment)
        {
            var post = await _postRepository.GetAsync(x => x.Id == createComment.PostId);
            var user = await _userRepository.GetAsync(x => x.Id == createComment.UserId);
            if(post == null || user == null)
            {
                return new BaseResponse()
                {
                    Message = "Post does not exist or user does not exist",
                    Success = false
                };
            }
            var comment = new Comment
            {
                PostId = createComment.PostId,
                UserId = createComment.UserId,
                Date = createComment.Date,
                Comments = createComment.Comments
            };
            await _commentRepository.CreateAsync(comment);
            return new BaseResponse()
            {
                Message = "Comment was created successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteComment(int CommentId)
        {
            var comment = await _commentRepository.GetAsync(x => x.Id == CommentId);
            if(comment == null)
            {
                return new BaseResponse()
                {
                    Message = "Comment does not exist",
                    Success = false
                };
            }
            comment.IsDeleted = true;
            await _commentRepository.UpdateAsync(comment);
            return new BaseResponse()
            { 
                Message = "Comment was successfully deleted",
                Success = true,
            };

        }

        public async Task<BaseResponse> GetComment(int commentId)
        {
            var comment = await _commentRepository.GetAsync(x => x.Id == commentId);
            if(comment == null)
            {
                return new BaseResponse()
                { 
                    Message = "Comment does not exist",
                    Success = false
                };
               
            }
            return new SingleCommentResponse()
            {
                Data = new GetCommentDto
                {
                    Id = comment.Id,
                    PostId = comment.PostId,
                    UserId = comment.UserId,
                    Comments = comment.Comments,
                    Date = comment.Date,
                },
                Message = "Comment retrieved successfully",
                Success = true
            };


        }

        public async Task<CommentResponse> GetCommentPyPostId(int PostId)
        {
            var comment = await _commentRepository.GetCommentByPostId(PostId);

            return new CommentResponse()
            {
                Data = comment.Select(x => new GetCommentDto
                {
                    Id = x.Id,
                    PostId = x.PostId,
                    UserId = x.UserId,
                    Date = x.Date,
                    Comments = x.Comments

                }).ToList(),
            };
        }
  
    }
}
