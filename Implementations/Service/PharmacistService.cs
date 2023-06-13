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
    public class PharmacistService : IPharmacistService
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public PharmacistService(IPharmacistRepository pharmacistRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _pharmacistRepository = pharmacistRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> AddPharmacist(CreatePharmacistDto createPharmacist)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Pharmacist\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (createPharmacist.CreateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createPharmacist.CreateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(createPharmacist.CreateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createPharmacist.CreateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var pharmacist = await _pharmacistRepository.GetAsync(a => a.User.Email == createPharmacist.CreateUserDto.Email);
            if (pharmacist != null)
            {
                return new BaseResponse()
                {
                    Message = "Pharmacist Already Exists",
                    Success = false,
                };
            }
            var user = new User
            {
                FirstName = createPharmacist.CreateUserDto.FirstName,
                LastName = createPharmacist.CreateUserDto.LastName,
                Email = createPharmacist.CreateUserDto.Email,
                Password = createPharmacist.CreateUserDto.Password,
                Picture = imagePath,
                Gender = createPharmacist.CreateUserDto.Gender,
                DateOfBirth = createPharmacist.CreateUserDto.DateOfBirth,
                PhoneNumber = createPharmacist.CreateUserDto.PhoneNumber,
                NextOfKin = createPharmacist.CreateUserDto.NextOfKin,
                Address = new Address
                {
                    NumberLine = createPharmacist.CreateUserDto.NumberLine,
                    Street = createPharmacist.CreateUserDto.Street,
                    City = createPharmacist.CreateUserDto.City,
                    State = createPharmacist.CreateUserDto.State,
                    Country = createPharmacist.CreateUserDto.Country,
                    PostalCode = createPharmacist.CreateUserDto.PostalCode,
                }
            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = await _roleRepository.GetAsync(x => x.Name.Equals("Pharmacist"));
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

            var pharmacists = new Pharmacist
            {
                UserId = adduser.Id,
                User = adduser,
            };
            await _pharmacistRepository.CreateAsync(pharmacists);
            return new BaseResponse
            {
                Message = "Pharmacist Added Successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> UpdatePharmacist(int id, UpdatePharmacistDto updatePharmacist)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Pharmacist\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updatePharmacist.UpdateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updatePharmacist.UpdateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updatePharmacist.UpdateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatePharmacist.UpdateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var pharmacist = await _pharmacistRepository.GetAsync(id);
            if (pharmacist == null)
            {
                return new BaseResponse
                {
                    Message = "Pharmacist Not Found",
                    Success = false,
                };
            }
            pharmacist.User.FirstName = updatePharmacist.UpdateUserDto.FirstName;
            pharmacist.User.LastName = updatePharmacist.UpdateUserDto.LastName;
            pharmacist.User.Email = updatePharmacist.UpdateUserDto.Email;
            pharmacist.User.Password = updatePharmacist.UpdateUserDto.Password;
            pharmacist.User.Picture = imagePath;
            pharmacist.User.Gender = updatePharmacist.UpdateUserDto.Gender;
            pharmacist.User.DateOfBirth = updatePharmacist.UpdateUserDto.DateOfBirth;
            pharmacist.User.PhoneNumber = updatePharmacist.UpdateUserDto.PhoneNumber;
            pharmacist.User.NextOfKin = updatePharmacist.UpdateUserDto.NextOfKin;
            pharmacist.User.Address.PostalCode = updatePharmacist.UpdateUserDto.PostalCode;
            pharmacist.User.Address.NumberLine = updatePharmacist.UpdateUserDto.NumberLine;
            pharmacist.User.Address.Street = updatePharmacist.UpdateUserDto.Street;
            pharmacist.User.Address.City = updatePharmacist.UpdateUserDto.City;
            pharmacist.User.Address.State = updatePharmacist.UpdateUserDto.State;
            pharmacist.User.Address.Country = updatePharmacist.UpdateUserDto.Country;


            await _pharmacistRepository.UpdateAsync(pharmacist);
            return new BaseResponse
            {
                Message = "Pharmacist updated successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> DeletePharmacist(int id)
        {
            var pharmacist = await _pharmacistRepository.GetAsync(pharmacist => pharmacist.IsDeleted == false && pharmacist.Id == id);
            if (pharmacist == null)
            {
                new BaseResponse
                { 
                    Message = "Pharmacist does not exist",
                    Success = false,
                };

            }
            pharmacist.IsDeleted = true;
            await _pharmacistRepository.UpdateAsync(pharmacist);
            return new BaseResponse
            {
                Message = "Pharmacist was successfully deleted",
                Success = true,
            };

        }

        public async Task<PharmacistResponse> GetAllPharmacists()
        {
            var pharmacists = await _pharmacistRepository.GetAllAsync();
            return new PharmacistResponse
            {
                Data = pharmacists.Select(x => new GetPharmacistDto
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

        public async Task<BaseResponse> GetPharmacist(int id)
        {
            var pharmacist = await _pharmacistRepository.GetAsync(id);
            return new SinglePharmacistResponse
            {
                Data = new GetPharmacistDto()
                {
                    Id = pharmacist.Id,
                    GetUserDto = new GetUserDto()
                    {
                        FirstName = pharmacist.User.FirstName,
                        LastName = pharmacist.User.LastName,
                        Email = pharmacist.User.Email,
                        Gender = pharmacist.User.Gender,
                        DateOfBirth = pharmacist.User.DateOfBirth,
                        Picture = pharmacist.User.Picture,
                        PhoneNumber = pharmacist.User.PhoneNumber,
                        NextOfKin = pharmacist.User.NextOfKin,
                        PostalCode = pharmacist.User.Address.PostalCode,
                        NumberLine = pharmacist.User.Address.NumberLine,
                        Street = pharmacist.User.Address.Street,
                        City = pharmacist.User.Address.City,
                        State = pharmacist.User.Address.State,
                        Country = pharmacist.User.Address.Country
                    }
                }
            };
        }

        public async Task<PharmacistResponse> GetPharmacistsbyName(string name)
        {
            var pharmacists = await _pharmacistRepository.GetPharmacistByName(name);
            return new PharmacistResponse
            {
                Data = pharmacists.Select(x => new GetPharmacistDto
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
