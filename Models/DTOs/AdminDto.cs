using Hospital_App.Entities.Enums;
using Hospital_App.Entities.Identity;

namespace Hospital_App.Models.DTOs
{
    public class CreateAdminDto
    {
        
        public CreateUserDto CreateUserDto { get; set; }
     

    }
    public class UpdateAdminDto
    {
        
        public UpdateUserDto UpdateUserDto { get; set; }

    }
    public class GetAdminDto
    {
        public int Id { get; set; }
        public GetUserDto GetUserDto { get; set; }
     

    }
}
