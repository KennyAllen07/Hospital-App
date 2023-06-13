using Hospital_App.Entities.Identity;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.IRepository;

namespace Hospital_App.Implementations.Service
{
    public class BioDataService : IBioDataService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBioDataRepository _bioDataRepository;

        public BioDataService(IBioDataRepository bioDataRepository, IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _bioDataRepository = bioDataRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;

        }

        public async Task<BaseResponse> AddBiodata(CreateBioDataDto createBioData)
        {
            var biodata = await _bioDataRepository.GetAsync(x => x.PatientId == createBioData.PatientId);
            if(biodata != null)
            {
                return new BaseResponse()
                {
                    Message  = "Your Biodata already exists",
                    Success = false,
                };

            }
            var bio = new BioData
            {
                PatientId = createBioData.PatientId,
                Height = createBioData.Height,
                Weight = createBioData.Weight,
                Genotype = createBioData.Genotype,
                BloodType = createBioData.BloodType,


            };
            await _bioDataRepository.CreateAsync(bio);
            return new BaseResponse()
            {
                Message = "BioData Created Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteBioData(int id)
        {
            var bioData = await _bioDataRepository.GetAsync(x => x.Id == id);
            if(bioData == null)
            {
                return new BaseResponse()
                {
                    Message = "Your BioData does not exist",
                    Success = false,
                };
            }
            bioData.IsDeleted = true;
            await _bioDataRepository.UpdateAsync(bioData);
            return new BaseResponse()
            {
                Message = "Your BioData has been successfully",
                Success = true,
            };
        }

        public async Task<BioDataResponse> GetAllBioData()
        {
            var bioData = await _bioDataRepository.GetAllAsync();
            return new BioDataResponse()
            {
                Data = bioData.Select(x => new GetBioDataDto
                {
                    Height= x.Height,
                    Weight= x.Weight,
                    PatientId = x.PatientId,
                    Genotype = x.Genotype,
                    BloodType = x.BloodType,
                    
                }).ToList(),
                Message = "BioData Retrieved Successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> GetBioDataByPatientId(int Patientid)
        {
            var biodata = await _bioDataRepository.GetBioDataByPatientId(Patientid);
            if(biodata == null)
            {
                return new BioDataResponse()
                { 
                    Success = false,
                    Message = "Biodata does not exist",
                };

            }
            return new SingleBioDataResponse
            {
                Data = new GetBioDataDto()
                {
                    Id = biodata.Id,
                    PatientId = biodata.PatientId,
                    Weight = biodata.Weight,
                    Height = biodata.Height,
                    Genotype = biodata.Genotype,
                    BloodType = biodata.BloodType,
                },
                Message = "Biodata retrieved Successfully",
                Success= true,

            };
        }

        public async Task<BaseResponse> UpdateBioData(UpdateBioDataDto updateBiodata, int id)
        {
            var bioData = await _bioDataRepository.GetAsync(x => x.Id==id);
            if(bioData == null)
            {
                return new BaseResponse()
                {
                    Message = "Your BioData does not exist",
                    Success = false,
                };
            }
            bioData.Weight = updateBiodata.Weight;
            bioData.Height = updateBiodata.Height;
            bioData.BloodType = updateBiodata.BloodType;
            bioData.Genotype= updateBiodata.Genotype;
            await _bioDataRepository.UpdateAsync(bioData);
            return new BaseResponse()
            {
                Message = "Your BioData has been updated successfully",
                Success = true,
            };
        }
    }
}
