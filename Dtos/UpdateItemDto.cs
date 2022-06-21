using System.ComponentModel.DataAnnotations;

namespace CatLog.Dtos{
    public record UpdateItemDto{
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal price { get; init; }
    }
}