using KutuphaneSistemi.Data;
using KutuphaneSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Controllers
{
    // Kategoriler denetleyicisi - Kategori CRUD işlemlerini yönetir
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kategori listesi - her kategorinin kitap sayısıyla birlikte
        public async Task<IActionResult> Index()
        {
            var kategoriler = await _context.Categories
                .Include(c => c.Books)
                .OrderBy(c => c.Name)
                .ToListAsync();

            return View(kategoriler);
        }

        // Kategori detayları - kategoriye ait kitaplarla birlikte
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var kategori = await _context.Categories
                .Include(c => c.Books)
                    .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (kategori == null) return NotFound();

            return View(kategori);
        }

        // Kategori ekleme formu (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Kategori ekleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                TempData["Basari"] = $"'{kategori.Name}' kategorisi başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // Kategori düzenleme formu (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var kategori = await _context.Categories.FindAsync(id);
            if (kategori == null) return NotFound();

            return View(kategori);
        }

        // Kategori düzenleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category kategori)
        {
            if (id != kategori.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategori);
                    await _context.SaveChangesAsync();
                    TempData["Basari"] = $"'{kategori.Name}' kategorisi başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Categories.Any(c => c.Id == kategori.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // Kategori silme onay sayfası (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var kategori = await _context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (kategori == null) return NotFound();

            return View(kategori);
        }

        // Kategori silme işlemi (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategori = await _context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (kategori == null) return NotFound();

            // Güvenli silme kontrolü: Kategoriye ait kitap varsa silme
            if (kategori.Books.Any())
            {
                TempData["Hata"] = $"'{kategori.Name}' kategorisine ait {kategori.Books.Count} kitap bulunduğu için silinemez. Önce kitapları silin veya başka bir kategoriye atayın.";
                return RedirectToAction(nameof(Index));
            }

            _context.Categories.Remove(kategori);
            await _context.SaveChangesAsync();
            TempData["Basari"] = $"'{kategori.Name}' kategorisi başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
