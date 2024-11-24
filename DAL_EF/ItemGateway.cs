using library_managment_system.Models;
using Microsoft.EntityFrameworkCore;

namespace library_managment_system.DAL_EF
{
    public class ItemGateway
    {
        private AppDbContext _context;
        public ItemGateway(AppDbContext context) 
        {
            _context = context;
        }
        public List<Item> GetAllItem()
        {
            List<Item> item = new List<Item>();
            item = _context.Item.Include(x => x.Category).ToList();
            return item;
        }
        public Item? GetItemById(int Id)
        {
            Item? item = new Item();
            item = _context.Item.FirstOrDefault(x => x.Id == Id);
            return item;
        }
        public int AddNewItem(Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
            return item.Id;
        }
        public int UpdateItem(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return item.Id;
        }
        public int RemoveItem(Item item)
        {
            try
            {
                _context.Item.Remove(item);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
