using System;

namespace CatLog.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset CreateDate { get; init; }
    }
}