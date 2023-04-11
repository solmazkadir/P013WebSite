using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P013WebSite.Data;
using P013WebSite.Entities;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: CategoriesController
        public ActionResult Index() //list seçeneği ile oluşturulur
        {
            var model = context.Categories.ToList(); //null reference hatası almamak için
            return View(model);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                context.Categories.Add(collection); //context üzerindeki Categories tablosuna collection daki kategoriyi ekle
                context.SaveChanges();//değişiklikleri kaydet
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = context.Categories.Find(id); //gelen idyi Categories tablosundan bul ve model değişkeninin içine ata
            return View(model); //modeli view e gönder
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                context.Categories.Update(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
