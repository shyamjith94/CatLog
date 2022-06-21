using System.ComponentModel.DataAnnotations;

namespace CatLog.Dtos{
    public record CreateItemDto{
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal price { get; init; }
    }
}