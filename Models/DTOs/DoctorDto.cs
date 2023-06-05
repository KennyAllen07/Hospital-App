namespace Hospital_App.Models.DTOs
{
    public class CreateDoctorDto
    {
        
        public CreateUserDto CreateUserDto { get; set; }
      
    }
    public class UpdateDoctorDto
    {
        
        public UpdateUserDto UpdateUserDto { get; set; }

    }
    public class GetDoctorDto
    {
        public int Id { get; set; }
        public GetUserDto GetUserDto { get; set; }
      
    }
}
