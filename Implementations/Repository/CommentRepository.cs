using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hospital_App.Implementations.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository 
    {
        public CommentRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Comment>> GetCommentByPostId(int postId)
        {
            return await _Context.Comments.Include(comment => comment.User).Where(x => x.PostId == postId).ToListAsync();
        }

        public async Task<IList<Comment>> GetCommentsByDateAdded(DateTime dateAdded)
        {
            return await _Context.Comments.Include(comment => comment.Post).ThenInclude(comment => comment.User).Where(x => x.IsDeleted == false && x.CreatedOn == dateAdded).ToListAsync();
        }

      
    }
}
