using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IComplaintService
    {
        Task<BaseResponse> AddComplaint(CreateComplaintsDto createComplaints, int id);
        Task<BaseResponse> UpdateComplaint(UpdateComplaintsDto updateComplaints, int id);
        Task<BaseResponse> DeleteComplaint(int id);
        
        Task<ComplaintsResponse> GetAllComplaintsByDateAdded(DateTime dateAdded);
        Task<ComplaintsResponse> GetAllComplaints();
        

    }
}
