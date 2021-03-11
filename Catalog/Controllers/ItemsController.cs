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

    }
}