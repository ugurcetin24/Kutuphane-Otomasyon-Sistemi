using KutuphaneSistemi.Data;
using KutuphaneSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Controllers
{
    // Yazarlar denetleyicisi - Yazar CRUD işlemlerini yönetir
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Yazar listesi - her yazarın kitap sayısıyla birlikte
        public async Task<IActionResult> Index()
        {
            // LINQ ile yazarları ve kitap sayılarını getir
            var yazarlar = await _context.Authors
                .Include(a => a.Books)
                .OrderBy(a => a.FullName)
                .ToListAsync();

            return View(yazarlar);
        }

        // Yazar detayları - yazara ait kitaplarla birlikte
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var yazar = await _context.Authors
                .Include(a => a.Books)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (yazar == null) return NotFound();

            return View(yazar);
        }

        // Yazar ekleme formu (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yazar ekleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author yazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yazar);
                await _context.SaveChangesAsync();
                TempData["Basari"] = $"'{yazar.FullName}' yazarı başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }

        // Yazar düzenleme formu (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var yazar = await _context.Authors.FindAsync(id);
            if (yazar == null) return NotFound();

            return View(yazar);
        }

        // Yazar düzenleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Author yazar)
        {
            if (id != yazar.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yazar);
                    await _context.SaveChangesAsync();
                    TempData["Basari"] = $"'{yazar.FullName}' yazarı başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Authors.Any(a => a.Id == yazar.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }

        // Yazar silme onay sayfası (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var yazar = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (yazar == null) return NotFound();

            return View(yazar);
        }

        // Yazar silme işlemi (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yazar = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (yazar == null) return NotFound();

            // Güvenli silme kontrolü: Yazarın kitabı varsa silme
            if (yazar.Books.Any())
            {
                TempData["Hata"] = $"'{yazar.FullName}' yazarına ait {yazar.Books.Count} kitap bulunduğu için silinemez. Önce kitapları silin veya başka bir yazara atayın.";
                return RedirectToAction(nameof(Index));
            }

            _context.Authors.Remove(yazar);
            await _context.SaveChangesAsync();
            TempData["Basari"] = $"'{yazar.FullName}' yazarı başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
