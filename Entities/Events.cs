namespace Hospital_App.Entities
{
    public class Events
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }
        public string EventDetails { get; set; }
        public DateTime Date { get; set; }
    }
}
