using CatLog.Entities;

namespace CatLog.Repositories
{
    public interface IInMemItemRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
    }
}