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
        private readonly IInMemItemRepository repository;
        public ItemController(IInMemItemRepository repository){
            this.repository = repository;
        }

        // Get /item
        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        // Get item/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = repository.GetItem(id);
            if (item is null){
                return NotFound();
            }
            return Ok(item.AsDto());
        }
        // Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                price = itemDto.price,
                CreateDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
    }

}