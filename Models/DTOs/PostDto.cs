using Hospital_App.Entities;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Models.DTOs
{
    public class CreatePostDto
    {
        public IFormFile Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
    }
    public class UpdatePostDto
    {
        public int Id { get; set; }
        public IFormFile Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
   public class GetPostDto
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set;}
    }

}
