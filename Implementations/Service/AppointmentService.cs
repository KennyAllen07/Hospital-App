using Hospital_App.Entities;
using Hospital_App.Implementations.Repository;
using Hospital_App.Interface.IRepository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        

        public AppointmentService(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;

        }

        public async Task<BaseResponse> AddAppointment(CreateAppointmentDto createAppointment)
        {
            var patient = await _patientRepository.GetAsync(x => x.User.Patient.Id == createAppointment.PatientId);
            var doctor = await _doctorRepository.GetAsync(x => x.User.Doctor.Id == createAppointment.DoctorId);
            if(patient == null || doctor == null || patient == null & doctor !=null || patient != null & doctor == null)
            {
                return new BaseResponse()
                { 
                    Message = "Patient or Doctor does not exist",
                    Success = false,
                };

            }
            var appointment = new Appointment
            {
                PatientId = createAppointment.PatientId,
                DoctorId = createAppointment.DoctorId,
                AppointmentDate = createAppointment.AppointmentDate,
            };
            await _appointmentRepository.CreateAsync(appointment);
            return new BaseResponse()
            {
                Message = "Appointment created successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAsync(x => x.Id == id);
            if(appointment == null)
            {
                return new BaseResponse()
                {
                    Message = "This appointment does not exist",
                    Success = false,
                };
            }
            appointment.IsDeleted = true;
            await _appointmentRepository.UpdateAsync(appointment);
            return new BaseResponse()
            {
                Message = "Appointment has been successfully deleted",
                Success = true,
            };

        }

        public async Task<AppointmentResponse> GetAllAppointments(int PatientId)
        {
            var appointment = await _appointmentRepository.GetAppointmentsByPatientId(PatientId);
            return new AppointmentResponse()
            {
                Data = appointment.Select(x => new GetAppointmentDto
                {
                    DoctorId = x.DoctorId,
                    GetDoctor = new GetDoctorDto
                    {

                        GetUserDto = new GetUserDto
                        {
                            FirstName = x.Doctor.User.FirstName,
                            LastName = x.Doctor.User.LastName,
                            Email = x.Doctor.User.Email,
                            Picture = x.Doctor.User.Picture
                        }

                    },

                    PatientId = x.PatientId,
                    GetPatient = new GetPatientDto
                    {
                        GetUserDto = new GetUserDto
                        {
                            FirstName = x.Patient.User.FirstName,
                            LastName = x.Patient.User.LastName,
                            Gender = x.Patient.User.Gender,
                            Email = x.Patient.User.Email,
                            PhoneNumber = x.Patient.User.PhoneNumber,
                            Picture = x.Patient.User.Picture,
                            NumberLine = x.Patient.User.Address.NumberLine,
                            Street = x.Patient.User.Address.Street,
                            City = x.Patient.User.Address.City,
                            State = x.Patient.User.Address.State,
                            Country = x.Patient.User.Address.Country,

                        }
                    },
                    AppointmentDate = x.AppointmentDate,
                }).ToList(),
                Message = "Appointments Retrieved Successfully",
                Success = true
            };
        }

        public async Task<AppointmentResponse> GetAllAppointments()
        {
            var appointment = await _appointmentRepository.GetAllAsync();
            return new AppointmentResponse()
            {
                Data = appointment.Select(x => new GetAppointmentDto
                {
                    DoctorId= x.DoctorId,
                    GetDoctor = new GetDoctorDto
                    { 

                        GetUserDto = new GetUserDto
                        {
                            FirstName = x.Doctor.User.FirstName,
                            LastName = x.Doctor.User.LastName,
                            Email = x.Doctor.User.Email,
                            Picture = x.Doctor.User.Picture,
                        }

                    },

                    PatientId = x.PatientId,
                    GetPatient = new GetPatientDto
                    {
                        GetUserDto = new GetUserDto
                        {
                            FirstName = x.Patient.User.FirstName,
                            LastName = x.Patient.User.LastName,
                            Gender = x.Patient.User.Gender,
                            Email = x.Patient.User.Email,
                            PhoneNumber = x.Patient.User.PhoneNumber,
                            Picture = x.Patient.User.Picture,
                            NumberLine = x.Patient.User.Address.NumberLine,
                            Street = x.Patient.User.Address.Street,
                            City = x.Patient.User.Address.City,
                            State = x.Patient.User.Address.State,
                            Country = x.Patient.User.Address.Country,

                        }
                    },
                    AppointmentDate= x.AppointmentDate,
                }).ToList(),
                Message = "Appointments Retrieved Successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAsync(x => x.Id == id);
            if(appointment == null)
            {
                return new BaseResponse()
                {
                    Message = "Appointment does not exist",
                    Success = false
                };
            }
            return new SingleAppointmentResponse()
            {
                Data =  new GetAppointmentDto
                {
                    DoctorId = appointment.DoctorId,
                    GetDoctor = new GetDoctorDto
                    {

                        GetUserDto = new GetUserDto
                        {
                            FirstName = appointment.Doctor.User.FirstName,
                            LastName = appointment.Doctor.User.LastName,
                            Email = appointment.Doctor.User.Email,
                            Picture = appointment.Doctor.User?.Picture,
                        }

                    },

                    PatientId = appointment.PatientId,
                    GetPatient = new GetPatientDto
                    {
                        GetUserDto = new GetUserDto
                        {
                            FirstName = appointment.Patient.User.FirstName,
                            LastName = appointment.Patient.User.LastName,
                            Gender = appointment.Patient.User.Gender,
                            Email = appointment.Patient.User.Email,
                            PhoneNumber = appointment.Patient.User.PhoneNumber,
                            Picture = appointment.Patient.User.Picture,
                            NumberLine = appointment.Patient.User.Address.NumberLine,
                            Street = appointment.Patient.User.Address.Street,
                            City = appointment.Patient.User.Address.City,
                            State = appointment.Patient.User.Address.State,
                            Country = appointment.Patient.User.Address.Country,

                        }
                    },
                    AppointmentDate = appointment.AppointmentDate,
                }
                
            };
        }

        public async Task<BaseResponse> UpdateAppointment(int id, UpdateAppointmentDto updateAppointment)
        {
            var appointment = await _appointmentRepository.GetAsync(x => x.Id == id);
            if(appointment == null || appointment.LastModifiedOn <= DateTime.Now)
            {
                return new BaseResponse()
                {
                    Message = "Appointment does not exist",
                    Success = false,
                };

            }
            appointment.AppointmentDate = updateAppointment.AppointmentDate;
            await _appointmentRepository.UpdateAsync(appointment);
            return new BaseResponse()
            {
                Message = "Your Appointment has been updated successfully",
                Success = true,
            };

        }
    }
}
