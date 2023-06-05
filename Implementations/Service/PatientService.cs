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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IWalletRepository _walletRepository;


        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWalletRepository walletRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _walletRepository = walletRepository;
        }

        public async Task<BaseResponse> AddPatient(CreatePatientDto createPatient)
        {
            var patient = await _patientRepository.GetAsync(a => a.User.Email == createPatient.CreateUserDto.Email);
            if (patient != null)
            {
                return new BaseResponse()
                {
                    Message = "Doctor Already Exist",
                    Success = false,
                };
            }
            var user = new User
            {
                FirstName = createPatient.CreateUserDto.FirstName,
                LastName = createPatient.CreateUserDto.LastName,
                Email = createPatient.CreateUserDto.Email,
                Password = createPatient.CreateUserDto.Password,
                Picture = createPatient.CreateUserDto.Picture,
                Gender = createPatient.CreateUserDto.Gender,
                DateOfBirth = createPatient.CreateUserDto.DateOfBirth,
                PhoneNumber = createPatient.CreateUserDto.PhoneNumber,
                NextOfKin = createPatient.CreateUserDto.NextOfKin,
                Address = new Address
                {
                    NumberLine = createPatient.CreateUserDto.NumberLine,
                    Street = createPatient.CreateUserDto.Street,
                    City = createPatient.CreateUserDto.City,
                    State = createPatient.CreateUserDto.State,
                    Country = createPatient.CreateUserDto.Country,
                    PostalCode = createPatient.CreateUserDto.PostalCode,
                }
            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = await _roleRepository.GetAsync(x => x.Name.Equals("Patient"));
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

            var patients = new Patient
            {
                UserId = adduser.Id,
                User = adduser,
            };
           

            var addPatient = await _patientRepository.CreateAsync(patients);
            var wallet = new Wallet
            {
                PatientId = addPatient.Id,
                AccountNumber = addPatient.Wallet.AccountNumber,
                Bank = addPatient.Wallet.Bank,
                FirstName = addPatient.User.FirstName,
                LastName = addPatient.User.LastName,
                PIN = addPatient.Wallet.PIN

            };
            var addWallet = await _walletRepository.CreateAsync(wallet);
            return new BaseResponse
            {
                Message = "Patient Added Successfully",
                Success = true,
            };

        }
        public async Task<BaseResponse> UpdatePatient(int id, UpdatePatientDto updatePatient)
        {
            var patient = await _patientRepository.GetAsync(id);
            if (patient == null)
            {
                return new BaseResponse
                {
                    Message = "Patient Not Found",
                    Success = false,
                };
            }
            patient.User.FirstName = updatePatient.UpdateUserDto.FirstName;
            patient.User.LastName = updatePatient.UpdateUserDto.LastName;
            patient.User.Email = updatePatient.UpdateUserDto.Email;
            patient.User.Password = updatePatient.UpdateUserDto.Password;
            patient.User.Picture = updatePatient.UpdateUserDto.Picture;
            patient.User.Gender = updatePatient.UpdateUserDto.Gender;
            patient.User.DateOfBirth = updatePatient.UpdateUserDto.DateOfBirth;
            patient.User.PhoneNumber = updatePatient.UpdateUserDto.PhoneNumber;
            patient.User.NextOfKin = updatePatient.UpdateUserDto.NextOfKin;
            patient.User.Address.PostalCode = updatePatient.UpdateUserDto.PostalCode;
            patient.User.Address.NumberLine = updatePatient.UpdateUserDto.NumberLine;
            patient.User.Address.Street = updatePatient.UpdateUserDto.Street;
            patient.User.Address.City = updatePatient.UpdateUserDto.City;
            patient.User.Address.State = updatePatient.UpdateUserDto.State;
            patient.User.Address.Country = updatePatient.UpdateUserDto.Country;


            await _patientRepository.UpdateAsync(patient);
            return new BaseResponse
            {
                Message = "Patient updated successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetAsync(patient => patient.IsDeleted == false && patient.Id == id);
            if (patient == null)
            {
                return new BaseResponse
                {
                    Message = "Patient not found",
                    Success = false
                };
            }

            patient.IsDeleted = true;
            await _patientRepository.UpdateAsync(patient);
            return new BaseResponse
            {
                Message = "Patient was Successfully Deleted",
                Success = true
            };
        }

        public async Task<PatientResponse> GetAllPatients()
        {
            var patient = await _patientRepository.GetAllAsync();
            return new PatientResponse
            {
                Data = patient.Select(x => new GetPatientDto
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

        public async Task<PatientResponse> GetPatientByName(string name)
        {
            var doctors = await _patientRepository.GetPatientByName(name);
            return new PatientResponse
            {
                Data = doctors.Select(x => new GetPatientDto
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

        public async Task<BaseResponse> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            return new SinglePatientResponse
            {
                Data = new GetPatientDto()
                {
                    Id = patient.Id,
                    GetUserDto = new GetUserDto()
                    {
                        FirstName = patient.User.FirstName,
                        LastName = patient.User.LastName,
                        Email = patient.User.Email,
                        Gender = patient.User.Gender,
                        DateOfBirth = patient.User.DateOfBirth,
                        Picture = patient.User.Picture,
                        PhoneNumber = patient.User.PhoneNumber,
                        NextOfKin = patient.User.NextOfKin,
                        PostalCode = patient.User.Address.PostalCode,
                        NumberLine = patient.User.Address.NumberLine,
                        Street = patient.User.Address.Street,
                        City = patient.User.Address.City,
                        State = patient.User.Address.State,
                        Country = patient.User.Address.Country
                    }
                }
            };
        }
    }
}
