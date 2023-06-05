namespace Hospital_App.Models.DTOs.ResponseModels
{
    public class RoleResponse : BaseResponse
    {
        public List<GetRoleDto> Data { get; set; } = new List<GetRoleDto>();
    }
}
