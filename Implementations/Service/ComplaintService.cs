using Hospital_App.Entities.Identity;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repository;
using Hospital_App.Interface.IService;
using Hospital_App.Interfaces.IRepository;
using Hospital_App.Models.DTOs;
using Hospital_App.Models.DTOs.ResponseModels;
using Hospital_App.Implementations.Repositories;

namespace Hospital_App.Implementations.Service
{
    public class ComplaintService : IComplaintService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository, IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _complaintRepository = complaintRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
           
        }

        public async Task<BaseResponse> AddComplaint(CreateComplaintsDto createComplaints, int Patientid)
        {
            var patient = await _patientRepository.GetAsync(a => a.Id == Patientid);
            if (patient == null)
            {
                return new BaseResponse
                {
                    Message = "Can't Make A Complaint",
                    Success = true,
                };

            }
            var complaint = new Complaints
            {
                Description = createComplaints.Description,
                PatientId = createComplaints.PatientId,


            };

            var addComplaint = await _complaintRepository.CreateAsync(complaint);
            return new BaseResponse
            {
                Message = "Complaint Created Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteComplaint(int id)
        {
            var complaint = await _complaintRepository.GetAsync(id);
            if(complaint == null)
            {
                return new BaseResponse
                {
                    Message = "Complaint Not Found",
                    Success = false,
                };

            }
            complaint.IsDeleted = true;
            await _complaintRepository.UpdateAsync(complaint);
            return new BaseResponse
            {
                Message = "Complaint was Deleted Successfully",
                Success = true,
            };
        }

        public async Task<ComplaintsResponse> GetAllComplaints()
        {
            var complaint = await _complaintRepository.GetAllAsync();
            return new ComplaintsResponse
            {
                Data = complaint.Select(x => new GetComplaintsDto
                {
                    Description = x.Description,
                    PatientId = x.PatientId,
                    Name = x.Patient.User.FirstName,

                   
                }).ToList()
            };
        }

        public async Task<ComplaintsResponse> GetAllComplaintsByDateAdded(DateTime dateAdded)
        {
            var complaint = await _complaintRepository.GetComplaintsByDateAdded(dateAdded);
            return new ComplaintsResponse
            {
                Data = complaint.Select(x => new GetComplaintsDto
                {
                    
                    PatientId = x.PatientId,
                    Name = x.Patient.User.FirstName,
                    Description = x.Description,
                   
                }).ToList()
            };

        }

        public async Task<BaseResponse> UpdateComplaint(UpdateComplaintsDto updateComplaints, int id)
        {
            var reqComplaint = await _complaintRepository.GetAsync(x => x.Id== id);
            if (reqComplaint == null)
            {
                return new BaseResponse
                {
                    Message = "Complaint does not exist",
                    Success = true,
                };

            }
           
            reqComplaint.Description = updateComplaints.Description;
            var addComplaint = await _complaintRepository.UpdateAsync(reqComplaint);
            return new BaseResponse
            {
                Message = "Complaint Updated Successfully",
                Success = true,
            };
        }
    }
}
