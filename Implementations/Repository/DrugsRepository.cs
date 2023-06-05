using Hospital_App.Context;
using Hospital_App.Entities;
using Hospital_App.Implementations.Repositories;
using Hospital_App.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hospital_App.Implementations.Repository
{
    public class DrugsRepository : GenericRepository<Drugs>, IDrugsRepository
    {
        public DrugsRepository(HospitalApplicationContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Drugs>> SortDrugsByDateAddedAsync(DateTime dateAdded)
        {
            return await _Context.Drugs
           .Include(drug => drug.User).Where(x => x.IsDeleted == false && x.CreatedOn == dateAdded)
           .ToListAsync();
        }

        public async Task<IList<Drugs>> SortDrugsByDateUpdatedAsync(DateTime dateUpdated)
        {
            return await _Context.Drugs
          .Include(drug => drug.User).Where(x => x.IsDeleted == false && x.LastModifiedOn == dateUpdated)
          .ToListAsync();
        }

        public async Task<IList<Drugs>> SortDrugsByMonth(DateTime month)
        {
            return await _Context.Drugs
          .Include(drugs => drugs.User).Where(x => x.IsDeleted == false && $"{x.CreatedOn}".Contains($"{month}"))
          .ToListAsync();
        }

        public async Task<IList<Drugs>> SortDrugsByName(string name)
        {
            return await _Context.Drugs
           .Include(drugs => drugs.User).Where(x => x.IsDeleted == false && x.Name == name)
           .ToListAsync();
        }

        public async Task<IList<Drugs>> SortDrugsByPrice(decimal price)
        {
            return await _Context.Drugs
            .Include(drugs => drugs.User).Where(x => x.IsDeleted == false && x.Price == price)
            .ToListAsync();
        }

        public async Task<IList<Drugs>> SortDrugsByYear(DateTime year)
        {
            return await _Context.Drugs
            .Include(drugs => drugs.User).Where(x => x.IsDeleted == false && $"{x.CreatedOn}".Contains($"{year}"))
            .ToListAsync();
        }
    }
}

