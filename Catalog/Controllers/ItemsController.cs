using System.Linq;
using System;
using System.Collections.Generic;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Models;
using Catalog.Dtos;
namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InterfaceItemsRepository repository;

        public ItemsController(InterfaceItemsRepository repository) 
        {
            this.repository = repository;
        }
        //GET /Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        //GET /Items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null) 
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto) 
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            if(item is null){
                return BadRequest();
            }
            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto) 
        {
            var existingItem = repository.GetItem(id);

            if(existingItem is null) {
                return NotFound();
            }

            Item updatedItem = existingItem with 
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
            
        }

        //DEL items/{id}
        [HttpDelete("{id}")]

        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if(existingItem is null) {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}