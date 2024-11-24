using library_managment_system.DAL_EF;
using library_managment_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library_managment_system.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext context;
        public CategoryGateway CategoryGateway;
        public IConfiguration configuration;
        public CategoryController(AppDbContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
            CategoryGateway = new CategoryGateway(context);
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> category = new List<Category>();
            category = CategoryGateway.GetAllCategory();
            return View(category);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            Category category = new Category();
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            //ViewBag.CategoryList = CategoryGateway.GetAllCategories();
            return View(category);
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            //ViewBag.CategoryList = CategoryGateway.GetAllCategories();
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Model State Error";
                return View(new Category());
            }
            int rowAffected = CategoryGateway.AddNewCategory(category);

            if (rowAffected == 1)
            {
                ViewBag.Message = "Saved New Category Successfully";
                return View(new Category());
                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Not Saved";
                return View(new Category());
            }

        }
        [HttpGet]
        public ActionResult UpdateCategory(int Id)
        {
            
            Category? category = new Category();
            category = CategoryGateway.GetCategoryById(Id);
            if (category == null)
            {
                ViewBag.Message = "Item Not Found";
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid || category.Id == 0)
            {
                return View(category);
            }

            int rowAffected = CategoryGateway.UpdateCategory(category);
            if (rowAffected == 1)
            {
                ViewBag.Message = "Updated Successfull";
                return View(category);
            }
            else
            {
                ViewBag.Message = "Not Updated";
                return View(category);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Category? category = CategoryGateway.GetCategoryById(Id);
            int rowAffected = 0;
            if (category == null)
            {
                ViewBag.Message = "Item Not Deleted : Id :" + Id + ", Name : " + category.Name;
                return View("Index");
            }
            else
            {
                rowAffected = CategoryGateway.RemoveCategory(category);
            }
            return RedirectToAction("Index");
        }
    }
}
