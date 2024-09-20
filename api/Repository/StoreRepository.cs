using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StoreRepository(ApplicationDBContext context) : IStoreRespository
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<List<Store>> GetStoresAsync()
        {
            var Stores = await _context.Stores.ToListAsync();
            return Stores;
        }

        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            var Store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            return Store;
        }

        public async Task<Store> CreateStoreAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Store?> UpdateStoreAsync(int id, Store store)
        {
            var Store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (Store == null)
            {
                return null;
            }

            Store.Name = store.Name;
            Store.Address = store.Address;
            Store.City = store.City;
            Store.Province = store.Province;
            Store.PostalCode = store.PostalCode;
            Store.Country = store.Country;
            await _context.SaveChangesAsync();
            return Store;
        }

        public async Task<Store?> DeleteStoreAsync(int id)
        {
            var Store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);

            if (Store == null)
            {
                return null;
            }

            _context.Stores.Remove(Store);
            await _context.SaveChangesAsync();
            return Store;
        }
        
    }
}