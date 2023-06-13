using Hospital_App.Entities;
using Hospital_App.Interface.Repository;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IList<Comment>> GetCommentByPostId(int postId);
        Task<IList<Comment>> GetCommentsByDateAdded(DateTime dateAdded);
    }
}
