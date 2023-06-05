using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IPharmacistService
    {
        Task<BaseResponse> AddPharmacist(CreatePharmacistDto createPharmacist);
        Task<BaseResponse> UpdatePharmacist(int id, UpdatePharmacistDto updatePharmacist);
        Task<BaseResponse> DeletePharmacist(int id);
        Task<PharmacistResponse> GetAllPharmacists();
        Task<PharmacistResponse> GetPharmacistsbyName(string name);
        Task<BaseResponse> GetPharmacist(int id);
    }
}
