using System.Collections.Generic;
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
        public IEnumerable<Item> GetItems(){
            var items = repository.GetItems();
            return items;
        }

        // Get item/id
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){
            var item = repository.GetItem(id);
            if (item is null){
                return NotFound();
            }
            return Ok(item);
        }
    }

}