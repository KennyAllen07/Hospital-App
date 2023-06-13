
using Hospital_App.Entities;
using Hospital_App.Interface.IRepository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;

namespace Hospital_App.Implementations.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IDoctorRepository _doctorRepository;
       

        public EventService(IEventRepository eventRepository, IDoctorRepository doctorRepository)
        {
            _eventRepository = eventRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<BaseResponse> AddEvent(CreateEventDto createEvent)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Event\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (createEvent.Poster != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createEvent.Poster.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(createEvent.Poster.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createEvent.Poster.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var doctor = await _doctorRepository.GetAsync(x => x.Id == createEvent.DoctorId);
            if(doctor == null)
            {
                return new BaseResponse()
                {
                    Message = "Can't Create Event cause Doctor does not exist",
                    Success = false,
                };
            }
            var events = new Events
            { 
                DoctorId = createEvent.DoctorId,
                Poster = imagePath,
                Title = createEvent.Title,
                EventDetails = createEvent.EventDetails,
                Date = createEvent.Date
            };
            await _eventRepository.CreateAsync(events);
            return new BaseResponse()
            {
                Message ="Event Added Successfully",
                Success = true,
            };

        }

        public async Task<BaseResponse> DeleteEvent(int id)
        {
            var events = await _eventRepository.GetAsync(x => x.Id == id);
            if(events == null)
            {
                return new BaseResponse()
                {
                    Message = "Event does not exist",
                    Success = false,
                };
            }
            events.IsDeleted = true;
            await _eventRepository.UpdateAsync(events);
            return new BaseResponse()
            {
                Message = "Event was deleted successfully",
                Success = true,
            };

        }

        public async Task<EventResponse> GetAllEvents()
        {
            var events = await _eventRepository.GetAllAsync();
            return new EventResponse()
            {
                Data = events.Select(x => new GetEventDto
                {
                    Id = x.Id,
                    Title= x.Title,
                    EventDetails = x.EventDetails,
                    Date = x.Date,
                    Poster = x.Poster,
                    DoctorId = x.DoctorId,
                    Doctor = new GetDoctorDto
                    {
                        Id = x.Id,
                        GetUserDto = new GetUserDto
                        {
                            FirstName = x.Doctor.User.FirstName,
                            LastName = x.Doctor.User.LastName,
                            Email = x.Doctor.User.Email,
                        }

                    },
                }).ToList(),
                Message = "Events Retrieved Successfully",
                Success = true,
            };

        }

        public async Task<BaseResponse> GetEvent(int id)
        {
            var events = await _eventRepository.GetAsync(x => x.Id == id);
            if(events == null)
            {
                return new BaseResponse()
                { 
                    Message = "Event does not exist",
                    Success = false,
                };

            }
            return new SingleEventResponse()
           { 
                Data = new GetEventDto
                { 
                    Id = events.Id,
                    Poster = events.Poster,
                    DoctorId = events.DoctorId,
                    Date = events.Date,
                    Title = events.Title,
                    EventDetails = events.EventDetails,
                    Doctor = new GetDoctorDto
                    {
                        Id = events.Id,
                        GetUserDto = new GetUserDto
                        {
                            FirstName = events.Doctor.User.FirstName,
                            LastName = events.Doctor.User.LastName,
                            Email = events.Doctor.User.Email,
                        }

                    },

                },

                Message = "Event Retrieved Successfully",
                Success = true,
            };

        }

       

        public async Task<BaseResponse> UpdateEvent(UpdateEventDto updateEvent)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Event\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updateEvent.Poster != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateEvent.Poster.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updateEvent.Poster.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateEvent.Poster.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
            var events = await _eventRepository.GetAsync(x => x.Id == updateEvent.Id);
            if(events == null)
            {
                return new BaseResponse()
                { 
                    Message ="Event does not exist",
                    Success = false,
                };

            }
            events.Poster = imagePath;
            events.Title = updateEvent.Title;
            events.Date = updateEvent.Date;
            events.EventDetails = updateEvent.EventDetails;
            await _eventRepository.UpdateAsync(events);
            return new BaseResponse()
            { 
                Message = "Event was updated successfully",
                Success = true,
            };

        }
    }
}
