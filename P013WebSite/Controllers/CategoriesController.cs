using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;

namespace P013WebSite.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            if (id is null) //eğer adres çubuğundan id gönerilmemişse
            {
                return BadRequest(); //ekrana geçersiz istek hatası ver
            }
            var category = _context.Categories.Include(p=>p.Products).FirstOrDefault(c => c.Id == id); // id gönderilmişse db den kategoriyi ara
            if (category == null) //eğer kategori db deyoksa 
            {
                return NotFound(); //geriye bulunamadı hayası döndür
            }
            return View(category); // kategori bulunduysa ekrana yolla
        }
    }
}
