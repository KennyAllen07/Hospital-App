using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service
{
    public class PrescriptionService : IPrescriptionsService
    {
        private readonly IPrescriptionsRepository _prescriptionRepository;
        private readonly IPatientRepository _patientRepository;
        public PrescriptionService(IPatientRepository patientRepository, IPrescriptionsRepository prescriptionRepository)
        {
            _patientRepository = patientRepository;
            _prescriptionRepository = prescriptionRepository;
        }

        public Task<BaseResponse> AddPrescription(CreatePrescriptionsDto createPrescriptions)
        {
            throw new NotImplementedException();
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
            var prescriptions = await _prescriptionRepository.DeleteAsync(prescription);
            return new BaseResponse
            {
                Message = "Your Prescription has been deleted",
                Success = true,
            };
        }

        public async Task<BaseResponse> GetPrescription(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PrescriptionsResponse> GetPrescriptions()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdatePrescription(UpdatePrescriptionsDto updatePrescriptions)
        {
            throw new NotImplementedException();
        }
    }


   
}

