using Hospital_App.Entities.Identity;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service;


public class UserService : IUserService

{
    private readonly IUserRepository _repository;
    private readonly IRoleRepository _roleRepository;
    public UserService(IUserRepository repository, IRoleRepository roleRepository)
    {
        _repository = repository;
        _roleRepository = roleRepository;
    }

    public async Task<UserResponse> Login(string email, string password)
    {

        var user = await _repository.GetAsync(x => x.Email == email && x.Password == password);
        var role = await _roleRepository.GetAsync(x => x.Id == user.Id);
        return new UserResponse()
        {

            Data =
            {
                Id= user.Id,
                Role = new GetRoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description= role.Description,

                },
            }

        };
    }
    public async Task<BaseResponse> Delete(int id)
    {

        var user = await _repository.GetAsync(x => x.Id== id);
        if (user.IsDeleted == false){
            user.IsDeleted = true;
            await _repository.UpdateAsync(user);
        }
        return new BaseResponse()
        {

            Message = "User was Successfully Deleted",
            Success = true,

        };
    }
}
