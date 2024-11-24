using library_managment_system.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace library_managment_system.DAL_EF
{
    public class CategoryGateway
    {
        private AppDbContext _context;
        public CategoryGateway(AppDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAllCategory()
        {
            List<Category> category = new List<Category>();
            category = _context.Category.ToList();
            return category;
        }
        public Category? GetCategoryById(int Id)
        {
            Category? category = new Category();
            category = _context.Category.FirstOrDefault(x => x.Id == Id);
            return category;
        }
        public int AddNewCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return category.Id;
        }
        public int UpdateCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return category.Id;
        }
        public int RemoveCategory(Category category)
        {
            try
            {
                _context.Category.Remove(category);
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
