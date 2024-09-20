using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.Store;


namespace api.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoreController(IStoreRespository storeRespository): ControllerBase
    {
        private readonly IStoreRespository _storeRespository = storeRespository;

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stores = await _storeRespository.GetStoresAsync();
            var storesDto = stores.Select(store => store.ToStoreDto());
            return Ok(storesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _storeRespository.GetStoreByIdAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store.ToStoreDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreDto storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var new_store = storeDto.ToStoreFromCreateStoreDto();
            var store = await _storeRespository.CreateStoreAsync(new_store);

            if (store == null)
            {
                return StatusCode(500, "A problem occurred while creating the store.");
            }

            return CreatedAtAction(nameof(GetStoreById), new { id = store.Id }, store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] UpdateStoreDto storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var store = storeDto.ToStoreFromUpdateStoreDto();

            var updated_store = await _storeRespository.UpdateStoreAsync(id, store);
            if (updated_store == null)
            {
                return StatusCode(500, "A problem occurred while updating the store.");
            }

            return Ok(updated_store.ToStoreDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _storeRespository.DeleteStoreAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store.ToStoreDto());
        }

        
    }
}