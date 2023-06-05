using Hospital_App.Entities;
using Hospital_App.Interface.Repository;

namespace Hospital_App.Interfaces.IRepository
{
    public interface IPrescriptionsRepository : IGenericRepository<Prescriptions>
    {
        Task<IList<Prescriptions>> GetPrescriptionsByDoctorId(int DoctorId);
        Task<IList<Prescriptions>> GetPrescriptionsByPatientId(int PatientId);
       
    }
}
