using Hospital_App.Entities;

namespace Hospital_App.Models.DTOs
{
    public class CreateEventDto
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public IFormFile Poster { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public DateTime Date { get; set; }
    }
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public IFormFile Poster { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public DateTime Date { get; set; }
    }
    public class GetEventDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public DateTime Date { get; set; }

    }
}
