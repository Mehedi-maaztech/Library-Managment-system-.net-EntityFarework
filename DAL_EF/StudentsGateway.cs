using library_managment_system.Models;

namespace library_managment_system.DAL_EF
{
    public class StudentsGateway
    {
        private AppDbContext _context;
        public StudentsGateway(AppDbContext context)
        {
            _context = context;
        }
        public List<Students> GetAllStudents()
        {
            List<Students> students = new List<Students>();
            students = _context.Students.ToList();
            return students;
        }
        public Students? GetStudentsById(int Id)
        {
            Students? students = new Students();
            students = _context.Students.FirstOrDefault(x => x.Id == Id);
            return students;
        }
        public int AddNewStudents(Students students)
        {
            _context.Students.Add(students);
            _context.SaveChanges();
            return students.Id;
        }
        public int UpdateStudents(Students students)
        {
            _context.Update(students);
            _context.SaveChanges();
            return students.Id;
        }
        public int RemoveStudents(Students students)
        {
            try
            {
                _context.Students.Remove(students);
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
