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

namespace Hospital_App.Implementations.Service
{
    public class DoctorService : IDoctorService 
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
       
        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository; 
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> AddDoctor(CreateDoctorDto createDoctor)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Doctor\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (createDoctor.CreateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createDoctor.CreateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(createDoctor.CreateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createDoctor.CreateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var doctor = await _doctorRepository.GetAsync(a => a.User.Email == createDoctor.CreateUserDto.Email);
            if (doctor != null)
            {
                return new BaseResponse()
                {
                    Message = "Doctor Already Exist",
                    Success = false,
                };
            }
            var user = new User
            {
                FirstName = createDoctor.CreateUserDto.FirstName,
                LastName = createDoctor.CreateUserDto.LastName,
                Email = createDoctor.CreateUserDto.Email,
                Password = createDoctor.CreateUserDto.Password,
                Picture = imagePath,
                Gender = createDoctor.CreateUserDto.Gender,
                DateOfBirth = createDoctor.CreateUserDto.DateOfBirth,
                PhoneNumber = createDoctor.CreateUserDto.PhoneNumber,
                NextOfKin = createDoctor.CreateUserDto.NextOfKin,
                Address = new Address
                {
                    NumberLine = createDoctor.CreateUserDto.NumberLine,
                    Street = createDoctor.CreateUserDto.Street,
                    City = createDoctor.CreateUserDto.City,
                    State = createDoctor.CreateUserDto.State,
                    Country = createDoctor.CreateUserDto.Country,
                    PostalCode = createDoctor.CreateUserDto.PostalCode,
                }
            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = await _roleRepository.GetAsync(x => x.Name.Equals("Doctor"));
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

            var doctors = new Doctor
            {
                UserId = adduser.Id,
                User = adduser,
            };
            await _doctorRepository.CreateAsync(doctors);
            return new BaseResponse
            {
                Message = "Doctor Added Successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> UpdateDoctor(int id, UpdateDoctorDto updateDoctor)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Doctor\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updateDoctor.UpdateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateDoctor.UpdateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updateDoctor.UpdateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateDoctor.UpdateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var doctor = await _doctorRepository.GetAsync(id);
            if (doctor == null)
            {
                return new BaseResponse
                {
                    Message = "Doctor Not Found",
                    Success = false,
                };
            }
                doctor.User.FirstName = updateDoctor.UpdateUserDto.FirstName;
                doctor.User.LastName = updateDoctor.UpdateUserDto.LastName;
                doctor.User.Email = updateDoctor.UpdateUserDto.Email;
                doctor.User.Password = updateDoctor.UpdateUserDto.Password;
                doctor.User.Picture = imagePath;
                doctor.User.Gender = updateDoctor.UpdateUserDto.Gender;
                doctor.User.DateOfBirth = updateDoctor.UpdateUserDto.DateOfBirth;
                doctor.User.PhoneNumber = updateDoctor.UpdateUserDto.PhoneNumber;
                doctor.User.NextOfKin = updateDoctor.UpdateUserDto.NextOfKin;
                doctor.User.Address.PostalCode = updateDoctor.UpdateUserDto.PostalCode;
                doctor.User.Address.NumberLine = updateDoctor.UpdateUserDto.NumberLine;
                doctor.User.Address.Street = updateDoctor.UpdateUserDto.Street;
                doctor.User.Address.City = updateDoctor.UpdateUserDto.City;
                doctor.User.Address.State = updateDoctor.UpdateUserDto.State;
                doctor.User.Address.Country = updateDoctor.UpdateUserDto.Country;


            await _doctorRepository.UpdateAsync(doctor);
            return new BaseResponse
            {
                Message = "Doctor updated successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> DeleteDoctor(int id)
        {
            var doctor = await _doctorRepository.GetAsync(doctor => doctor.IsDeleted == false && doctor.Id == id);
            if (doctor == null)
            {
                return new BaseResponse
                {
                    Message = "Doctor not found",
                    Success = false
                };
            }

            doctor.IsDeleted = true;
            await _doctorRepository.UpdateAsync(doctor);
            return new BaseResponse
            {
                Message = "Doctor Successfully Deleted",
                Success = true
            };
        }

        public async Task<DoctorResponse> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetDoctors();
            return new DoctorResponse
            {
                Data = doctors.Select(x => new GetDoctorDto
                {
                    Id = x.Id,
                    GetUserDto = new GetUserDto()
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        Email = x.User.Email,
                        Gender = x.User.Gender,
                        DateOfBirth = x.User.DateOfBirth,
                        Picture= x.User.Picture,
                        PhoneNumber= x.User.PhoneNumber,
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

        public async Task<DoctorResponse> GetAllDoctorsByName(string name)
        {
            var doctors = await _doctorRepository.GetDoctorByName(name);
            return new DoctorResponse
            {
                Data = doctors.Select(x => new GetDoctorDto
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

        public async Task<BaseResponse> GetDoctor(int id)
        {
            var doctors = await _doctorRepository.GetDoctor(id);
            return new SingleDoctorResponse
            {
                Data = new GetDoctorDto()
                {
                    Id = doctors.Id,
                    GetUserDto = new GetUserDto()
                    {
                        FirstName = doctors.User.FirstName,
                        LastName = doctors.User.LastName,
                        Email = doctors.User.Email,
                        Gender = doctors.User.Gender,
                        DateOfBirth = doctors.User.DateOfBirth,
                        Picture = doctors.User.Picture,
                        PhoneNumber = doctors.User.PhoneNumber,
                        NextOfKin = doctors.User.NextOfKin,
                        PostalCode = doctors.User.Address.PostalCode,
                        NumberLine = doctors.User.Address.NumberLine,
                        Street = doctors.User.Address.Street,
                        City = doctors.User.Address.City,
                        State = doctors.User.Address.State,
                        Country = doctors.User.Address.Country
                    }
                }
            };
        }

        
    }
}
