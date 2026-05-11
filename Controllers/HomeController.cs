using KutuphaneSistemi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // İstatistik verileri
            ViewBag.ToplamKitap = await _context.Books.CountAsync();
            ViewBag.ToplamYazar = await _context.Authors.CountAsync();
            ViewBag.ToplamKategori = await _context.Categories.CountAsync();
            ViewBag.MüsaitKitap = await _context.Books.CountAsync(b => b.IsAvailable);
            ViewBag.MüsaitDegilKitap = await _context.Books.CountAsync(b => !b.IsAvailable);

            // Öne çıkan 4 kitap (en eski eklenenler - istikrarlı görünüm için)
            ViewBag.OncuKitaplar = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .OrderBy(b => b.Id)
                .Take(4)
                .ToListAsync();

            // Son eklenen 5 kitap (model olarak geçirilir)
            var sonKitaplar = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .OrderByDescending(b => b.Id)
                .Take(5)
                .ToListAsync();

            return View(sonKitaplar);
        }
    }
}
