using Hospital_App.Entities;
using Hospital_App.Entities.Identity;
using Hospital_App.Interface.IRepository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;
using Microsoft.VisualBasic;
using System.Reflection;

namespace Hospital_App.Implementations.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            
        }

        public async Task<BaseResponse> AddPost(CreatePostDto createPost, int userId)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Post\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (createPost.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createPost.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(createPost.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createPost.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var post = new Posts
            {
                Title = createPost.Title,
                Description = createPost.Description,
                UserId = userId,
                Likes = 0,
                Picture = imagePath,

            };
            await _postRepository.CreateAsync(post);
            return new BaseResponse()
            { 
                Message = "Post was created successfully",
                Success= true,
            };

        }

        public async Task<BaseResponse> DeletePost(int id)
        {
            var  post = await _postRepository.GetAsync(id);
            if(post == null)
            {
                return new BaseResponse()
                {
                    Message = "Post does not exist",
                    Success = false,
                };
            }
            post.IsDeleted = true;
            await _postRepository.UpdateAsync(post);
            return new BaseResponse()
            {
                Message = "Post has been deleted",
                Success = true,
            };

        }

        public async Task<PostResponse> GetAllPosts()
        {
            var post = await _postRepository.GetAllAsync();
            return new PostResponse()
            {
                Data = post.Select( x=> new GetPostDto()
                {
                    Description = x.Description,
                    Title = x.Title,
                    Picture = x.Picture,
                    Likes = x.Likes
                }).ToList(),
            };
        }

        public async Task<PostResponse> GetAllPostsByNoofLikes()
        {
            var post = await _postRepository.GetPostByNoofLikes();
            return new PostResponse()
            {
                Data = post.Select(x => new GetPostDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Picture = x.Picture,
                    Title = x.Title,
                    Likes= x.Likes,
                    
                }).ToList(),
            };
        }

        public async Task<PostResponse> GetAllPostsByUserId(int userId)
        {
            var post = await _postRepository.GetPostByUserId(userId);
            return new PostResponse()
            { 
                Data = post.Select(x => new GetPostDto
                {
                    Id = x.Id,
                    Description= x.Description,
                    Likes= x.Likes,
                    Picture = x.Picture,
                    Title = x.Title

                }).ToList(),
            };

        }

        public async Task<BaseResponse> GetPost(int id)
        {
            var post = await _postRepository.GetAsync(x => x.Id == id);
            if(post == null)
            {
                return new BaseResponse()
                {
                    Message = "Post does not exist",
                    Success = false
                };
            }
            return new SinglePostResponse
            { 
                Data = new GetPostDto
                { 
                    Id = post.Id,
                    Description = post.Description,
                    Title = post.Title,
                    Picture = post.Picture,
                    Likes= post.Likes,
                },
                Message = "Post retrieved successfully",
                Success= true,

            };

        }

        public async Task<BaseResponse> UpdatePost(UpdatePostDto updatePost)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Post\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updatePost.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updatePost.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updatePost.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatePost.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var post = await _postRepository.GetAsync(x => x.Id == updatePost.Id);
            if(post == null)
            {
                return new BaseResponse()
                {
                    Message = "Post does not exist",
                    Success= false
                };

            }
            post.Description = updatePost.Description;
            post.Title = updatePost.Title;
            post.Picture = imagePath;
            await _postRepository.UpdateAsync(post);
            return new BaseResponse()
            {
                Message = "Post has been updated successfully",
                Success = true,
            };

        }
        public async Task<BaseResponse> AddLike(int userId, int postId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            var post = await _postRepository.GetAsync(x => x.Id == postId);
            if(user == null || post == null)
            {
                return new BaseResponse()
                {
                    Message = "User does not exist or Post does not exist",
                    Success = false
                };
            }
            post.Likes += 1;
            await _postRepository.UpdateAsync(post);
            return new BaseResponse()
            {
                Message = "Likes has been updated successfully",
                Success = true,
            };



        }
    }
}
