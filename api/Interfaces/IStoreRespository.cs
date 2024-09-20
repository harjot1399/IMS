using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStoreRespository
    {
        Task <List<Store>> GetStoresAsync();

        Task<Store?> GetStoreByIdAsync(int id);

        Task<Store> CreateStoreAsync(Store store);

        Task<Store?> UpdateStoreAsync(int id, Store store);

        Task<Store?> DeleteStoreAsync(int id);
    }
}