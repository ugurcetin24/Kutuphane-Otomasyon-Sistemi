using System.ComponentModel.DataAnnotations;

namespace KutuphaneSistemi.Models
{
    // Yazar tablosunu temsil eden model sınıfı
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Yazar adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Doğum Yılı")]
        [Range(1000, 2100, ErrorMessage = "Doğum yılı 1000 ile 2100 arasında olmalıdır.")]
        public int? BirthYear { get; set; }

        [MaxLength(50, ErrorMessage = "Ülke adı en fazla 50 karakter olabilir.")]
        [Display(Name = "Ülke")]
        public string? Country { get; set; }

        [MaxLength(500, ErrorMessage = "Biyografi en fazla 500 karakter olabilir.")]
        [Display(Name = "Biyografi")]
        public string? Biography { get; set; }

        // Bir yazarın birden fazla kitabı olabilir (One-to-Many ilişkisi)
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
