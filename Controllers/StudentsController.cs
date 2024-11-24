using library_managment_system.DAL_EF;
using library_managment_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_managment_system.Controllers
{
    public class StudentsController : Controller
    {
        private AppDbContext context;
        public CategoryGateway CategoryGateway;
        public StudentsGateway StudentsGateway;
        
        public StudentsController(AppDbContext context)
        {
            CategoryGateway = new CategoryGateway(context);
            StudentsGateway = new StudentsGateway(context);
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Students> students = new List<Students>();
            students = StudentsGateway.GetAllStudents();
            return View(students);
        }
        [HttpGet]
        public ActionResult AddStudents()
        {
            Students students = new Students();
            return View(students);
        }
        [HttpPost]
        public ActionResult AddStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Model State Error";
                return View(new Students());
            }
            int rowAffected = StudentsGateway.AddNewStudents(students);

            if (rowAffected == 1)
            {
                ViewBag.Message = "Saved New Category Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Not Saved";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult UpdateStudents(int Id)
        {
            Students? students = new Students();
            students = StudentsGateway.GetStudentsById(Id);
            if (students == null)
            {
                ViewBag.Message = "Item Not Found";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateStudents(Students students)
        {
            if (!ModelState.IsValid || students.Id == 0)
            {
                return View(students);
            }

            int rowAffected = StudentsGateway.UpdateStudents(students);
            if (rowAffected == 1)
            {
                ViewBag.Message = "Updated Successfull";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Not Updated";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Students? students = StudentsGateway.GetStudentsById(Id);
            int rowAffected = 0;
            if (students == null)
            {
                ViewBag.Message = "Item Not Deleted : Id :" + Id + ", Name : " + students.Name;
                return View("Index");
            }
            else
            {
                rowAffected = StudentsGateway.RemoveStudents(students);
            }
            return RedirectToAction("Index");
        }
    }
}
