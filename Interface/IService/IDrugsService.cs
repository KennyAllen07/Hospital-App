using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IDrugsService
    {
        Task<BaseResponse> AddDrug(CreateDrugsDto createDrug);
        Task<BaseResponse> UpdateDrug(UpdateDrugsDto updateDrugs);
        Task<BaseResponse> DeleteDrug(int id);
        Task<BaseResponse> GetDrug(int id);
        Task<DrugsResponse> GetAllDrugs();
        Task<DrugsResponse> GetAllDrugsByDateAdded(DateTime dateAdded);

    }
}
