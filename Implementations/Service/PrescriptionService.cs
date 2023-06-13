using Hospital_App.Entities;
using Hospital_App.Implementations.Repository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;
using Microsoft.VisualBasic;
using MimeKit.Encodings;

namespace Hospital_App.Implementations.Service
{
    public class PrescriptionService : IPrescriptionsService
    {
        private readonly IPrescriptionsRepository _prescriptionRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IComplaintRepository _complaintRepository;
        private readonly IDoctorRepository _doctorRepository;
        public PrescriptionService(IPatientRepository patientRepository, IPrescriptionsRepository prescriptionRepository, IComplaintRepository complaintRepository, IDoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _prescriptionRepository = prescriptionRepository;
            _complaintRepository = complaintRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<BaseResponse> AddPrescription(CreatePrescriptionsDto createPrescriptions, int DoctorId, int PatientId)
        {
            var patient = await _complaintRepository.GetComplaintsByPatientId(PatientId);
            var doctor = await _doctorRepository.GetAsync(DoctorId);
           
            

            if (patient == null && doctor == null)
            {
                return new BaseResponse
                {
                    Message = "Can't Make A Prescription",
                    Success = true,
                };

            }
            var prescription = new Prescriptions
            {
                Diagnosis = createPrescriptions.Diagnosis,
                Prescription = createPrescriptions.Prescription,
                

            };

            await _prescriptionRepository.CreateAsync(prescription);
            return new BaseResponse
            {
                Message = "Prescription Created Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeletePrescription(int Id)
        {
            var prescription = await _prescriptionRepository.GetAsync(Id);
            if (prescription == null)
            {
                return new BaseResponse
                { 
                    Message = "Prescription doesn't exist",
                    Success = false,
                };

            }
            prescription.IsDeleted = true;
            await _prescriptionRepository.UpdateAsync(prescription);
            return new BaseResponse
            {
                Message = "Your Prescription has been deleted",
                Success = true,
            };
        }

        public async Task<BaseResponse> GetPrescription(int Id)
        {
            var prescriptions = await _prescriptionRepository.GetAsync(x => x.Id == Id);
            if (prescriptions == null)
            {
                return new BaseResponse
                {
                    Message = "Prescription Not Found",
                    Success = false,
                };
            }
            return new SinglePrescriptionsResponse
            {
                Data = new GetPrescriptionsDto()
                {
                    Id = prescriptions.Id,
                    Diagnosis = prescriptions.Diagnosis,
                    PatientId = prescriptions.PatientId,
                    DoctorId = prescriptions.DoctorId,
                    Prescription = prescriptions.Prescription,
                    
                },
                Message = "Prescription Retrieved Successfully",
                Success = true
            };
        }

        public async Task<PrescriptionsResponse> GetPrescriptions()
        {
            var prescription = await _prescriptionRepository.GetAllAsync();
            return new PrescriptionsResponse
            {
                Data = prescription.Select(x => new GetPrescriptionsDto
                {
                    Id = x.Id,
                    Diagnosis = x.Diagnosis,
                    PatientId = x.PatientId,
                    DoctorId = x.DoctorId,
                    Prescription = x.Prescription,



                }).ToList()
            };
        }

        public async Task<BaseResponse> UpdatePrescription(UpdatePrescriptionsDto updatePrescriptions, int DoctorId, int id)
        {
            var reqPresciption = await _prescriptionRepository.GetAsync(x => x.Id == id);
            var doctor = await _doctorRepository.GetAsync(DoctorId);
            if (reqPresciption == null && doctor == null || doctor == null || reqPresciption == null)
            {
                return new BaseResponse
                {
                    Message = "Prescription does not exist",
                    Success = true,
                };

            }

            reqPresciption.Prescription = updatePrescriptions.Prescription;
            reqPresciption.Diagnosis = updatePrescriptions.Diagnosis;
            await _prescriptionRepository.UpdateAsync(reqPresciption);
            return new BaseResponse
            {
                Message = "Prescription Updated Successfully",
                Success = true,
            };
        }
    }


   
}

