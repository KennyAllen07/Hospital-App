using Hospital_App.Models.DTOs.ResponseModels;
namespace Hospital_App.Models.DTOs
{
    public class CreateRoleDto
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class UpdateRoleDto
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class GetRoleDto : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
   

}
