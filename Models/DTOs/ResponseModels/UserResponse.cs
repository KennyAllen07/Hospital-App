
namespace Hospital_App.Models.DTOs.ResponseModels
{
    
    public class UserResponse : BaseResponse
    {
        public GetUserDto Data { get; set; } = new GetUserDto();
    }
}
