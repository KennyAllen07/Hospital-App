namespace Hospital_App.Models.DTOs
{
    public class CreatePharmacistDto
    {
        
        public CreateUserDto CreateUserDto { get; set; }
      

    }
    public class UpdatePharmacistDto
    {
        
        public UpdateUserDto UpdateUserDto { get; set; }

    }
    public class GetPharmacistDto
    {
        public int Id { get; set; }
        public GetUserDto GetUserDto { get; set; }
    

    }
}
