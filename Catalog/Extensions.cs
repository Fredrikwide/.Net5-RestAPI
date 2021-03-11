using Catalog.Models;
using Catalog.Dtos;

namespace Catalog
{
    public static class Extensions {
      public static ItemDto AsDto(this Item item)
      {
        return new ItemDto {
          Id = item.Id,
          Name = item.Name,
          Price = item.Price,
          CreatedDate = item.CreatedDate
        };
      }
    }
}