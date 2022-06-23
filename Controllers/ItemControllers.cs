using System.Collections.Generic;
using System.Linq;
using CatLog.Dtos;
using CatLog.Entities;
using CatLog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatLog.Controllers{
    // Get /item
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository repository;
        public ItemController(IItemRepository repository){
            this.repository = repository;
        }

        // Get /item
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync(){
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            return items;
        }

        // Get item/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id){
            var item = await  repository.GetItemAsync(id);
            if (item is null){
                return NotFound();
            }
            return item.AsDto();
        }
        // Post /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto itemDto){
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                price = itemDto.price,
                CreateDate = DateTimeOffset.UtcNow
            };
            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

        // Put /items/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto){
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null){
                return NotFound();
            }
            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                price = itemDto.price
            };

            await repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }
        //Delete /item/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id){
            var existingItem = repository.GetItemAsync(id);
            if (existingItem is null){
                return NotFound();
            }
            await repository.DeleteItemAsync(id);
            return NoContent();
        }
    }

}