using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public class CreateItemDto 
    {
      [Required]
      public string Name { get; init; }
      [Required]
      [Range(1, 9999)]
      public decimal Price { get; init; }
    }
}