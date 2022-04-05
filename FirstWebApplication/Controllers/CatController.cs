using FirstWebApplication.Data;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers
{
    public class CatController : Controller
    {
        private readonly AplicationDb _db;

        public CatController(AplicationDb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<CatCorm> catList = _db.catCorms.ToList();
            return View(catList);
        }
         //GET
        public IActionResult Create()
        {          
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CatCorm obj)
        {
            if (obj.Name == obj.Type.ToString())
            {
                ModelState.AddModelError("CustomError", "Ошибка!");
            }
                

            if(ModelState.IsValid) 
            { 
                _db.catCorms.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Create!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var catCormFromDb = _db.catCorms.Find(id);
            //var catCormFromDbFirst = _db.catCorms.FirstOrDefault(u=>u.Id == id);
            //var catCormFromDbSingle = _db.catCorms.SingleOrDefault(u => u.Id == id);

            if (catCormFromDb == null)
            {
                return NotFound();
            }
            return View(catCormFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CatCorm obj)
        {
            if (obj.Name == obj.Type.ToString())
            {
                ModelState.AddModelError("CustomError", "Ошибка!");
            }

            if (ModelState.IsValid)
            {
                _db.catCorms.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Update!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catCormFromDb = _db.catCorms.Find(id);

            if (catCormFromDb == null)
            {
                return NotFound();
            }
            return View(catCormFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.catCorms.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                
                _db.catCorms.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Delete!";
            return RedirectToAction("Index");                    
        }
    }
}
