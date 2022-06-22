using System;
using CatLog.Entities;
using System.Collections.Generic;
using System.Linq;
using CatLog.Repositories;

public class InMemItemRepository : IItemRepository
{
    private readonly List<Item> items = new()
    {
        new Item{Id=Guid.NewGuid(), Name="test", price=9, CreateDate=DateTimeOffset.UtcNow},
        new Item{Id=Guid.NewGuid(), Name="test1", price=10, CreateDate=DateTimeOffset.UtcNow},
        new Item{Id=Guid.NewGuid(), Name="test2", price=11, CreateDate=DateTimeOffset.UtcNow}
    };
    public IEnumerable<Item> GetItems()
    {
        return items;
    }
    public Item GetItem(Guid id)
    {
        return items.Where(item => item.Id == id).SingleOrDefault();
    }
    public void CreateItem(Item item) {
        items.Add(item);
    }
    public void UpdateItem(Item item){
        var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
        items[index] = item;
    }
    public void DeleteItem(Guid id){
         var index = items.FindIndex(existingItem => existingItem.Id == id);
        items.RemoveAt(index);
    }

}
