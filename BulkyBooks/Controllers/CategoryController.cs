global using BulkyBooks.Data;
global using BulkyBooks.Models;
global using Microsoft.AspNetCore.Mvc;

namespace BulkyBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BulkyBookDbContext _db;
        public CategoryController(BulkyBookDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //hack qilishmasligi uchun
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //qo'lbola validatsiya yaratish
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                //xatoliklar faqat summary yoki alohida field lar uchun yaratish mumkin 
                ModelState.AddModelError("name", "Nomi va tartib raqami bir xil bo'lishi mumkin emas");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        
        public IActionResult Edit(int? id)
        {
            if(id==null || id<=0)
            {
                return NotFound();
            }
            var obj = _db.Categories.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            
            return View(obj);
        }
        [HttpPost]
        //hack qilishmasligi uchun
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //qo'lbola validatsiya yaratish
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                //xatoliklar faqat summary yoki alohida field lar uchun yaratish mumkin 
                ModelState.AddModelError("name", "Nomi va tartib raqami bir xil bo'lishi mumkin emas");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var obj = _db.Categories.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
