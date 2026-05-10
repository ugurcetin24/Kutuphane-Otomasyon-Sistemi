using KutuphaneSistemi.Data;
using KutuphaneSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Controllers
{
    // Kitaplar denetleyicisi - Kitap CRUD işlemlerini yönetir
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kitap listesi - arama ve filtreleme özellikleriyle
        public async Task<IActionResult> Index(string? aramaMetni, int? kategoriId, int? yazarId)
        {
            // Tüm yazarları ve kategorileri dropdown için yükle
            ViewBag.Yazarlar = await _context.Authors.OrderBy(a => a.FullName).ToListAsync();
            ViewBag.Kategoriler = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            ViewBag.SecilenKategori = kategoriId;
            ViewBag.SecilenYazar = yazarId;
            ViewBag.AramaMetni = aramaMetni;

            // LINQ sorgusu - Include ile ilgili verileri (Yazar, Kategori) yükle
            var kitaplar = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsQueryable();

            // Arama filtresi: Başlığa göre filtrele
            if (!string.IsNullOrEmpty(aramaMetni))
            {
                kitaplar = kitaplar.Where(b => b.Title.Contains(aramaMetni));
            }

            // Kategori filtresi
            if (kategoriId.HasValue)
            {
                kitaplar = kitaplar.Where(b => b.CategoryId == kategoriId.Value);
            }

            // Yazar filtresi
            if (yazarId.HasValue)
            {
                kitaplar = kitaplar.Where(b => b.AuthorId == yazarId.Value);
            }

            var liste = await kitaplar.OrderBy(b => b.Title).ToListAsync();
            ViewBag.SonucSayisi = liste.Count;

            return View(liste);
        }

        // Kitap detayları
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var kitap = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (kitap == null) return NotFound();

            return View(kitap);
        }

        // Kitap ekleme formu (GET)
        public async Task<IActionResult> Create()
        {
            await DropdownlariDoldur();
            return View();
        }

        // Kitap ekleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book kitap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitap);
                await _context.SaveChangesAsync();
                TempData["Basari"] = $"'{kitap.Title}' kitabı başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }

            // Doğrulama hatası varsa dropdown'ları yeniden doldur
            await DropdownlariDoldur(kitap.AuthorId, kitap.CategoryId);
            return View(kitap);
        }

        // Kitap düzenleme formu (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var kitap = await _context.Books.FindAsync(id);
            if (kitap == null) return NotFound();

            await DropdownlariDoldur(kitap.AuthorId, kitap.CategoryId);
            return View(kitap);
        }

        // Kitap düzenleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book kitap)
        {
            if (id != kitap.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                    TempData["Basari"] = $"'{kitap.Title}' kitabı başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Books.Any(b => b.Id == kitap.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            await DropdownlariDoldur(kitap.AuthorId, kitap.CategoryId);
            return View(kitap);
        }

        // Kitap silme onay sayfası (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var kitap = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (kitap == null) return NotFound();

            return View(kitap);
        }

        // Kitap silme işlemi (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _context.Books.FindAsync(id);
            if (kitap != null)
            {
                _context.Books.Remove(kitap);
                await _context.SaveChangesAsync();
                TempData["Basari"] = $"Kitap başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        // Yardımcı metot: Create ve Edit formları için dropdown listelerini hazırlar
        private async Task DropdownlariDoldur(int? yazarId = null, int? kategoriId = null)
        {
            var yazarlar = await _context.Authors.OrderBy(a => a.FullName).ToListAsync();
            var kategoriler = await _context.Categories.OrderBy(c => c.Name).ToListAsync();

            ViewBag.AuthorId = new SelectList(yazarlar, "Id", "FullName", yazarId);
            ViewBag.CategoryId = new SelectList(kategoriler, "Id", "Name", kategoriId);
        }
    }
}
