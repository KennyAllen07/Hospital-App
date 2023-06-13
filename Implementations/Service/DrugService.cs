using Hospital_App.Entities.Identity;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service
{
    public class DrugService : IDrugsService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDrugsRepository _drugRepository;

        public DrugService(IDrugsRepository drugRepository, IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _drugRepository = drugRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> AddDrug(CreateDrugsDto createDrug, int UserId)
        {
            var user = await _userRepository.GetAsync(UserId);
            
            if(user == null)
            {
                return new BaseResponse()
                {
                    Message = "User Can't create drug",
                    Success = false
                };
            }
           
            var drugs = new Drugs 
            {
               Name = createDrug.Name,
               Price = createDrug.Price,
               Description = createDrug.Description,
               Quantity = createDrug.Quantity,

            };
            await _drugRepository.CreateAsync(drugs);
            return new BaseResponse()
            {
                Message = "Drug Created Successfully",
                Success = true,
            };


        }

        public async Task<BaseResponse> DeleteDrug(int id)
        {
            var drug = await _drugRepository.GetAsync(x => x.Id == id);
            if(drug == null)
            {
                return new BaseResponse()
                { 
                    Success = false,
                    Message = "Drug does not exist"
                };

            }
            drug.IsDeleted = true;
            await _drugRepository.UpdateAsync(drug);
            return new BaseResponse()
            { 
                Message = "Drug was successfully deleted",
                Success = true,
            };


        }

        public async Task<DrugsResponse> GetAllDrugs()
        {
            var drug = await _drugRepository.GetAllAsync();
            return new DrugsResponse
            {
                Data = drug.Select(x => new GetDrugsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Description = x.Description,

                }).ToList()
            };

        }

        public async Task<DrugsResponse> GetAllDrugsByDateAdded(DateTime dateAdded)
        {
            var drug = await _drugRepository.SortDrugsByDateAddedAsync(dateAdded);
            return new DrugsResponse
            { 
                Data = drug.Select(x => new GetDrugsDto 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Description = x.Description,

                }).ToList(),
            
            };

        }

        public async Task<BaseResponse> GetDrug(int id)
        {
            var drug = await _drugRepository.GetAsync(x => x.Id == id);
            if(drug == null)
            {
                return new BaseResponse()
                {
                    Message = "Drug does not exist",
                    Success = false,
                };
            }
            return new SingleDrugsResponse
            {
                Data = new GetDrugsDto
                {
                    Id= drug.Id,
                    Price = drug.Price,
                    Description = drug.Description,
                    Quantity = drug.Quantity,
                },
                Message = "Drug Retrieved Successfully",
                Success = true
                
            };

        }

        public async Task<BaseResponse> UpdateDrug(UpdateDrugsDto updateDrugs)
        {
            var drug = await _drugRepository.GetAsync(x => x.Id == updateDrugs.Id);
            if(drug == null)
            {
                return new BaseResponse()
                {
                    Message = "Drug does not exist",
                    Success = false,
                };

            }
            drug.Name = updateDrugs.Name;
            drug.Description = updateDrugs.Description;
            drug.Price = updateDrugs.Price;
            await _drugRepository.UpdateAsync(drug);
            return new BaseResponse()
            {
                Message = "Drug was updated successfully",
                Success = true
            };

        }
    }
}
