using System.ComponentModel.DataAnnotations;

namespace KutuphaneSistemi.Models
{
    // Kategori tablosunu temsil eden model sınıfı
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [MaxLength(80, ErrorMessage = "Kategori adı en fazla 80 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300, ErrorMessage = "Açıklama en fazla 300 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        // Bir kategorinin birden fazla kitabı olabilir (One-to-Many ilişkisi)
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
