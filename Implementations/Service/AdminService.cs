using Hospital_App.Context;
using Hospital_App.Contracts;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using System.Linq;
using System.Resources;
using Hospital_App.Models.DTOs;
using Hospital_App.Interface.IService;
using Hospital_App.Interface.Repository;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs.ResponseModels;
using Hospital_App.Entities.Identity;
using Hospital_App.Entities.Enums;
using Hospital_App.Implementations.Repository;

namespace Hospital_App.Implementations.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> AddAdmin(CreateAdminDto createAdmin)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Admin\\");
            if(!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if(createAdmin.CreateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createAdmin.CreateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(createAdmin.CreateUserDto.Picture.FileName);
                if(!System.IO.Directory.Exists(filePath))
                {
                    using(var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createAdmin.CreateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var admin = await _adminRepository.GetAsync(a => a.User.Email == createAdmin.CreateUserDto.Email);
            if (admin != null)
            {
                return new BaseResponse()
                {
                    Message = "Admin Already Exists",
                    Success = false,
                };
            }
            var user = new User
            {
                FirstName = createAdmin.CreateUserDto.FirstName,
                LastName = createAdmin.CreateUserDto.LastName,
                Email = createAdmin.CreateUserDto.Email,
                Password = createAdmin.CreateUserDto.Password,
            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = await _roleRepository.GetAsync(x => x.Name.Equals("Admin"));
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role not found",
                    Success = false
                };
            }

            var userRole = new UserRole
            {
                UserId = adduser.Id,
                RoleId = role.Id,
            };
            adduser.UserRoles.Add(userRole);
            await _userRepository.UpdateAsync(adduser);

            var admins = new Admin
            {
                UserId = adduser.Id,
                User = adduser,
            };
            await _adminRepository.CreateAsync(admins);
            return new BaseResponse
            {
                Message = "Admin Added Successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> UpdateAdmin(int id, UpdateAdminDto updateAdmin)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Admin\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updateAdmin.UpdateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateAdmin.UpdateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updateAdmin.UpdateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateAdmin.UpdateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var admin = await _adminRepository.GetAsync(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Not Found",
                    Success = false,
                };
            }
            admin.User.FirstName = updateAdmin.UpdateUserDto.FirstName;
            admin.User.LastName = updateAdmin.UpdateUserDto.LastName;
            admin.User.Email = updateAdmin.UpdateUserDto.Email;
            admin.User.Password = updateAdmin.UpdateUserDto.Password;
            admin.User.Picture = imagePath;
            admin.User.Gender = updateAdmin.UpdateUserDto.Gender;
            admin.User.DateOfBirth = updateAdmin.UpdateUserDto.DateOfBirth;
            admin.User.PhoneNumber = updateAdmin.UpdateUserDto.PhoneNumber;
            admin.User.NextOfKin = updateAdmin.UpdateUserDto.NextOfKin;
            admin.User.Address.PostalCode = updateAdmin.UpdateUserDto.PostalCode;
            admin.User.Address.NumberLine = updateAdmin.UpdateUserDto.NumberLine;
            admin.User.Address.Street = updateAdmin.UpdateUserDto.Street;
            admin.User.Address.City = updateAdmin.UpdateUserDto.City;
            admin.User.Address.State = updateAdmin.UpdateUserDto.State;
            admin.User.Address.Country = updateAdmin.UpdateUserDto.Country;


            await _adminRepository.UpdateAsync(admin);
            return new BaseResponse
            {
                Message = "Admin updated successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteAdmin(int Id)
        {
            var admin = await _adminRepository.GetAsync(admin => admin.IsDeleted == false && admin.Id == Id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Not Found",
                    Success = false,
                };
            }
            admin.IsDeleted = true;
            await _adminRepository.UpdateAsync(admin);
            return new BaseResponse
            { 
                Message = "Admin Deleted Successfully",
                Success = true,
            };


        }

        public async Task<BaseResponse> GetAdminById(int Id)
        {
            var admins = await _adminRepository.GetAdmin(Id);
            return new SingleAdminResponse
            {
                Data = new GetAdminDto()
                {
                    Id = admins.Id,
                    GetUserDto = new GetUserDto()
                    {
                        FirstName = admins.User.FirstName,
                        LastName = admins.User.LastName,
                        Email = admins.User.Email,
                        Gender = admins.User.Gender,
                        DateOfBirth = admins.User.DateOfBirth,
                        Picture = admins.User.Picture,
                        PhoneNumber = admins.User.PhoneNumber,
                        NextOfKin = admins.User.NextOfKin,
                        PostalCode = admins.User.Address.PostalCode,
                        NumberLine = admins.User.Address.NumberLine,
                        Street = admins.User.Address.Street,
                        City = admins.User.Address.City,
                        State = admins.User.Address.State,
                        Country = admins.User.Address.Country
                    }
                }
            };
        }


        public async Task<AdminResponse> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAllAsync(); 
            return new AdminResponse
            {
                Data = admins.Select(x => new GetAdminDto
                {
                    Id = x.Id,
                    GetUserDto = new GetUserDto()
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        Email = x.User.Email,
                        Gender = x.User.Gender,
                        DateOfBirth = x.User.DateOfBirth,
                        Picture = x.User.Picture,
                        PhoneNumber = x.User.PhoneNumber,
                        NextOfKin = x.User.NextOfKin,
                        PostalCode = x.User.Address.PostalCode,
                        NumberLine = x.User.Address.NumberLine,
                        Street = x.User.Address.Street,
                        City = x.User.Address.City,
                        State = x.User.Address.State,
                        Country = x.User.Address.Country
                    }
                }).ToList()
            };
        }

       
    }
}
