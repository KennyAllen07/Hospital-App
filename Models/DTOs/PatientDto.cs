namespace Hospital_App.Models.DTOs
{
    public class CreatePatientDto
    {
        
        public CreateUserDto CreateUserDto { get; set; }
       

    }
    public class UpdatePatientDto
    {
        
        public UpdateUserDto UpdateUserDto { get; set; }

    }
    public class GetPatientDto
    {
        public int Id { get; set; }
        public GetUserDto GetUserDto { get; set; }
        

    }
}
