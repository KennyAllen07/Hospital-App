namespace Hospital_App.Models.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
    public class UpdateUserRole
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
