using Hospital_App.Entities.Identity;
using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
    public class CreateCommentDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }

        public DateTime Date { get; set; }
    }
    public class GetCommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Posts Post { get; set; }
        public int UserId { get; set; }
        public GetUserDto User { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
    }
}
