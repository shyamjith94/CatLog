using System;

namespace CatLog.Dtos{
     public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset CreateDate { get; init; }
    }
}