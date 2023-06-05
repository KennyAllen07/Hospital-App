using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital_App.Implementations.Repository
{
    public class ComplaintRepository : GenericRepository<Complaints>, IComplaintRepository
    {
        public ComplaintRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Complaints>> GetComplaintsBetweenDates(DateTime startingDate, DateTime endingDate)
        {
            return await _Context.Complaints
        .Include(complaints => complaints.Patient).OrderByDescending(x => x.IsDeleted == false && x.CreatedOn >= startingDate && x.CreatedOn <= endingDate)
        .ToListAsync();
        }

        public async Task<IList<Complaints>> GetComplaintsByDateAdded(DateTime dateAdded)
        {
            return await _Context.Complaints
          .Include(complaints => complaints.Patient).Where(x => x.IsDeleted == false && x.CreatedOn == dateAdded)
          .ToListAsync();
        }

        public async Task<IList<Complaints>> GetComplaintsByMonth(DateTime month)
        {
           return await _Context.Complaints
          .Include(complaints => complaints.Patient).Where(x => x.IsDeleted == false && $"{x.CreatedOn}".Contains($"{month}"))
          .ToListAsync();
        }

        public async Task<IList<Complaints>> GetComplaintsByPatientId(int PatientId)
        {
            return await _Context.Complaints
           .Include(complaints => complaints.Patient).Where(x => x.IsDeleted == false && x.PatientId == PatientId)
           .ToListAsync();
        }

        public async Task<IList<Complaints>> GetComplaintsByYear(DateTime year)
        {
         return await _Context.Complaints
        .Include(complaints => complaints.Patient).Where(x => x.IsDeleted == false && $"{x.CreatedOn}".Contains($"{year}"))
        .ToListAsync();
        }
    }
}
