using library_managment_system.Models;
using Microsoft.EntityFrameworkCore;

namespace library_managment_system.DAL_EF
{
    public class BooklistGateway
    {
        private AppDbContext _context;
        public BooklistGateway(AppDbContext context)
        {
            _context = context;
        }
        public List<Booklist> GetAllBooklist()
        {
            List<Booklist> booklist = new List<Booklist>();
            booklist = _context.Booklist.Include(x => x.Category).ToList();
            return booklist;
        }
        public Booklist? GetBooklistById(int Id)
        {
            Booklist? booklist = new Booklist();
            booklist = _context.Booklist.FirstOrDefault(x => x.Id == Id);
            return booklist;
        }
        public int AddNewBooklist(Booklist booklist)
        {
            _context.Booklist.Add(booklist);
            _context.SaveChanges();
            return booklist.Id;
        }
        public int UpdateBooklist(Booklist booklist)
        {
            _context.Update(booklist);
            _context.SaveChanges();
            return booklist.Id;
        }
        public int RemoveBooklist(Booklist booklist)
        {
            try
            {
                _context.Booklist.Remove(booklist);
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
