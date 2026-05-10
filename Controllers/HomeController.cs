using KutuphaneSistemi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Controllers
{
    // Ana sayfa denetleyicisi - Dashboard istatistiklerini gösterir
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // LINQ ile veritabanından istatistik verilerini çek
            ViewBag.ToplamKitap = await _context.Books.CountAsync();
            ViewBag.ToplamYazar = await _context.Authors.CountAsync();
            ViewBag.ToplamKategori = await _context.Categories.CountAsync();
            ViewBag.MüsaitKitap = await _context.Books.CountAsync(b => b.IsAvailable);
            ViewBag.MüsaitDegilKitap = await _context.Books.CountAsync(b => !b.IsAvailable);

            // Son eklenen 5 kitabı göster
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
