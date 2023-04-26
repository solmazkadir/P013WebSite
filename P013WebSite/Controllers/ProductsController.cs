using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;

namespace P013WebSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var urunler = await _context.Products.Where(p => p.IsActive).ToListAsync();
            return View(urunler);
        }
        public async Task<IActionResult> Search(string q)
        {
            var urunler = await _context.Products.Where(p=>p.Name.Contains(q)).ToListAsync();
            return View(urunler);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) //eğer adres çubuğundan id gönderilmemişse
            {
                return BadRequest(); //ekrana geçersiz istek hatası ver
            }
            var product =await _context.Products.Include("Category").FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
