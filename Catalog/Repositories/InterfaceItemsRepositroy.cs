using System;
using System.Collections.Generic;
using Catalog.Models;

namespace Catalog.Repositories
{  
    public interface InterfaceItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }  
}