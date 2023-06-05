using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Hospital_App.Interface.Repository;
using Hospital_App.Context;
using Hospital_App.Contracts;
using Microsoft.EntityFrameworkCore;
using Hospital_App.Entities;
using Hospital_App.Interfaces.IRepository;

namespace Hospital_App.Implementations.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<Admin> GetAdmin(int Id)
        {
            return await _Context.Admins.Include(admin => admin.User).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IList<Admin>> GetAllAdminsAsync()
        {
            return await _Context.Admins
            .Include(admin => admin.User).Where(x => x.IsDeleted == false)
            .ToListAsync();
        }
    }
}