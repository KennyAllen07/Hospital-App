using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Implementations.Repository
{
    public class PostRepository : GenericRepository<Posts>, IPostRepository
    {
        public PostRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }



        public async Task<IList<Posts>> GetPostByNoofLikes()
        {
            return await _Context.Posts
            .Include(post => post.User).OrderByDescending(x => x.Likes).ToListAsync();
        }
        public async Task<IList<Posts>> GetPostByUserId(int UserId)
        {
            return await _Context.Posts
            .Include(post => post.User).Where(x => x.UserId == UserId).ToListAsync();
        }
    }
}
