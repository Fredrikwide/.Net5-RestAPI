using System.ComponentModel.DataAnnotations;
namespace Catalog.Dtos
{
    public record UpdateItemDto 
    {
      [RequiredAttribute]
      public string Name { get; init; }
      [RequiredAttribute]
      [Range(1, 9999)]
      public decimal Price { get; init; }
    }
}