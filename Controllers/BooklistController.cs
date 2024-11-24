using library_managment_system.DAL_EF;
using library_managment_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_managment_system.Controllers
{
    public class BooklistController : Controller
    {
        private AppDbContext context;
        public CategoryGateway CategoryGateway;
        public BooklistGateway BooklistGateway;
        public BooklistController(AppDbContext context)
        {
            CategoryGateway = new CategoryGateway(context);
            BooklistGateway = new BooklistGateway(context);
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Booklist> booklist = new List<Booklist>();
            booklist = BooklistGateway.GetAllBooklist();
            return View(booklist);
        }
        [HttpGet]
        public ActionResult AddBooklist()
        {
            Booklist booklist = new Booklist();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            return View(booklist);
        }
        [HttpPost]
        public ActionResult AddBooklist(Booklist booklist)
        {
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Model State Error";
                return View(new Booklist());
            }
            int rowAffected = BooklistGateway.AddNewBooklist(booklist);

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
        public ActionResult UpdateBooklist(int Id)
        {
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            Booklist? booklist = new Booklist();
            booklist = BooklistGateway.GetBooklistById(Id);
            if (booklist == null)
            {
                ViewBag.Message = "Item Not Found";
            }
            return View(booklist);
        }

        [HttpPost]
        public ActionResult UpdateBooklist(Booklist booklist)
        {
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            if (!ModelState.IsValid || booklist.Id == 0)
            {
                return View(booklist);
            }

            int rowAffected = BooklistGateway.UpdateBooklist(booklist);
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
            Booklist? booklist = BooklistGateway.GetBooklistById(Id);
            int rowAffected = 0;
            if (booklist == null)
            {
                ViewBag.Message = "Item Not Deleted : Id :" + Id + ", Name : " + booklist.Name;
                return View("Index");
            }
            else
            {
                rowAffected = BooklistGateway.RemoveBooklist(booklist);
            }
            return RedirectToAction("Index");
        }
    }
}
