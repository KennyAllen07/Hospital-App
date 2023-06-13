using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Interface.IService
{
    public interface IEventService 
    {
        Task<BaseResponse> AddEvent(CreateEventDto createEvent);
        Task<BaseResponse> UpdateEvent(UpdateEventDto updateEvent);
        Task<BaseResponse> DeleteEvent(int id);
        Task<BaseResponse> GetEvent(int id);
        Task<EventResponse> GetAllEvents();
       
    }
}
