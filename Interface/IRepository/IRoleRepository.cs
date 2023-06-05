using Hospital_App.Entities.Identity;
using Hospital_App.Interface.Repository;
using Hospital_App.Models.DTOs.ResponseModels;
using Hospital_App.Models.DTOs;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<BaseResponse> AddRoleAsync(CreateRoleDto role);
        Task<RoleResponse> GetAllRoleAsync();
        Task<BaseResponse> UpdateUserRole(UpdateUserRole userRole);
        Task<RoleResponse> GetRoleByUserId(int id);
    }
}
