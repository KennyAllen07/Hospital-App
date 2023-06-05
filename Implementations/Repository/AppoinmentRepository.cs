using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interface.Repository;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Hospital_App.Implementations.Repository
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

     
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _Context.Appointments
            .Include(appointment => appointment.Patient).Where(x => x.IsDeleted == false)
            .ToListAsync();
        }

        public async Task<IList<Appointment>> GetAppointmentBetweenDates(DateTime startDate, DateTime endDate)
        {
             return await _Context.Appointments
            .Include(appointments => appointments.Patient).OrderByDescending(x => x.IsDeleted == false && x.CreatedOn >= startDate && x.CreatedOn <= endDate)
            .ToListAsync();
        }

        public async Task<IList<Appointment>> GetAppointmentsByDateAdded(DateTime dateAdded)
        {
            return await _Context.Appointments
           .Include(appointment => appointment.Patient).Where(x => x.IsDeleted == false && x.CreatedOn == dateAdded)
           .ToListAsync();
        }

        public async Task<IList<Appointment>> GetAppointmentsByMonth(DateTime month)
        {
            return await _Context.Appointments
            .Include(appointments => appointments.Patient).Where(x => x.IsDeleted == false && $"{x.CreatedOn}".Contains($"{month}"))
            .ToListAsync();
        }

        public async Task<IList<Appointment>> GetAppointmentsByPatientId(int Id)
        {
            return await _Context.Appointments
           .Include(appointment => appointment.Patient).Where(x => x.IsDeleted == false && x.PatientId == Id)
           .ToListAsync();
        }

        public async Task<IList<Appointment>> GetAppointmentsByYear(DateTime year)
        {
            return await _Context.Appointments
           .Include(appointments => appointments.Patient).Where(x => x.IsDeleted == false && $"{x.CreatedOn}".Contains($"{year}"))
           .ToListAsync();
        }
    }
}
