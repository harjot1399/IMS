using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using api.Dtos.Store;
using api.Models;

namespace api.Mappers
{
    public static class StoreMappers
    {
        public static StoreDto ToStoreDto (this Store store)
        {
            return new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
                City = store.City,
                Province = store.Province,
                PostalCode = store.PostalCode,
                Country = store.Country
            };
        }


        public static Store ToStoreFromCreateStoreDto (this CreateStoreDto createStoreDto)
        {
            return new Store
            {
                Name = createStoreDto.Name,
                Address = createStoreDto.Address,
                City = createStoreDto.City,
                Province = createStoreDto.Province,
                PostalCode = createStoreDto.PostalCode,
                Country = createStoreDto.Country
            };
        }

        public static Store ToStoreFromUpdateStoreDto(this UpdateStoreDto updateStoreDto)
        {
            return new Store
            {
                Name = updateStoreDto.Name,
                Address = updateStoreDto.Address,
                City = updateStoreDto.City,
                Province = updateStoreDto.Province,
                PostalCode = updateStoreDto.PostalCode,
                Country = updateStoreDto.Country
            };
        }
    }
}