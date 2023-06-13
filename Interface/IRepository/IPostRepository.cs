using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interface.IRepository
{
    public interface IPostRepository : IGenericRepository<Posts>
    {
        
        Task<IList<Posts>> GetPostByUserId(int userId);
        Task<IList<Posts>> GetPostByNoofLikes();

    }
}
