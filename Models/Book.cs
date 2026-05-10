using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneSistemi.Models
{
    // Kitap tablosunu temsil eden model sınıfı
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [MaxLength(150, ErrorMessage = "Kitap adı en fazla 150 karakter olabilir.")]
        [Display(Name = "Kitap Adı")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(20, ErrorMessage = "ISBN en fazla 20 karakter olabilir.")]
        [Display(Name = "ISBN")]
        public string? ISBN { get; set; }

        [Display(Name = "Yayın Yılı")]
        [Range(1000, 2100, ErrorMessage = "Yayın yılı 1000 ile 2100 arasında olmalıdır.")]
        public int? PublicationYear { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        [Range(1, 10000, ErrorMessage = "Sayfa sayısı 1 ile 10000 arasında olmalıdır.")]
        public int? PageCount { get; set; }

        [MaxLength(50, ErrorMessage = "Raf konumu en fazla 50 karakter olabilir.")]
        [Display(Name = "Raf Konumu")]
        public string? ShelfLocation { get; set; }

        [Display(Name = "Müsait mi?")]
        public bool IsAvailable { get; set; } = true;

        // Yazar ile ilişki (zorunlu foreign key)
        [Required(ErrorMessage = "Yazar seçimi zorunludur.")]
        [Display(Name = "Yazar")]
        public int AuthorId { get; set; }

        // Kategori ile ilişki (zorunlu foreign key)
        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        // Navigation properties - EF Core ilgili verileri yüklemek için kullanır
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
