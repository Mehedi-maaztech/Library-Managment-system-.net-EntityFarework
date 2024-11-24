using library_managment_system.DAL_EF;
using library_managment_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_managment_system.Controllers
{
    public class ItemController : Controller
    {
        private AppDbContext context;
        public CategoryGateway CategoryGateway;
        public ItemGateway ItemGateway;
        public ItemController(AppDbContext context)
        {
            CategoryGateway = new CategoryGateway(context);
            ItemGateway = new ItemGateway(context);
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Item> item = new List<Item>();
            item = ItemGateway.GetAllItem();
            return View(item);
        }
        [HttpGet]
        public ActionResult AddItem()
        {
            Item item = new Item();
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            return View(item);
        }
        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Model State Error";
                return View(new Item());
            }
            int rowAffected = ItemGateway.AddNewItem(item);

            if (rowAffected == 1)
            {
                ViewBag.Message = "Saved New Category Successfully";
                return View(new Item());
                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Not Saved";
                return View(new Item());
            }
        }

        [HttpGet]
        public ActionResult UpdateItem(int Id)
        {
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            //select * from Items where Id=1
            Item? item = new Item();
            item = ItemGateway.GetItemById(Id);
            if (item == null)
            {
                ViewBag.Message = "Item Not Found";
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateItem(Item item)
        {
            //ViewBag.BrandList = BrandGateway.GetAllBrands();
            ViewBag.CategoryList = CategoryGateway.GetAllCategory();
            if (!ModelState.IsValid || item.Id == 0)
            {
                return View(item);
            }

            int rowAffected = ItemGateway.UpdateItem(item);
            if (rowAffected == 1)
            {
                ViewBag.Message = "Updated Successfull";
                return View(item);
            }
            else
            {
                ViewBag.Message = "Not Updated";
                return View(item);
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Item? item = ItemGateway.GetItemById(Id);
            int rowAffected = 0;
            if (item == null)
            {
                ViewBag.Message = "Item Not Deleted : Id :" + Id + ", Name : " + item.Name;
                return View("Index");
            }
            else
            {
                rowAffected = ItemGateway.RemoveItem(item);
            }
            return RedirectToAction("Index");
        }
    }
}
