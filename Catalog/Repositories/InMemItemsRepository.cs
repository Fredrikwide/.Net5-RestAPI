using System;
using System.Collections.Generic;
using Catalog.Models;
using System.Linq;

namespace Catalog.Repositories
{
  
  public class InMemItemsRepository : InterfaceItemsRepository
  {
    private readonly List<Item> items = new()
    {
      new Item { Id = Guid.NewGuid(), Name = "Health Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Mana Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 30, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Iron Shield", Price = 35, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Iron Axe", Price = 25, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Iron Dagger", Price = 15, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Wooden Staff", Price = 28, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Wooden Wand ", Price = 19, CreatedDate = DateTimeOffset.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Linen Cloak", Price = 55, CreatedDate = DateTimeOffset.UtcNow },
    };
    //Return All Items
    public IEnumerable<Item> GetItems()
    {
      return items;
    }
    //Return Single Item
    public Item GetItem(Guid id)
    {
      return items.SingleOrDefault(item => item.Id == id);
    }
    // Create Item
    public void CreateItem(Item item)
    {
      items.Add(item);
    }
    //Update Item
    public void UpdateItem(Item item)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
      items[index] = item;
    }

    //Delete Item
    public void DeleteItem(Item item)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
      items.RemoveAt(index);
    }
  }
}