using CatLog.Dtos;
using CatLog.Entities;

namespace CatLog{
    public static class Extensions{
        public static ItemDto AsDto(this Item item ){
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                price = item.price,
                CreateDate = item.CreateDate
            };
        }
    }
}