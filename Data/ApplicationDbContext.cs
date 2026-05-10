using KutuphaneSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Data
{
    // Veritabanı bağlamı - Entity Framework Core ile veritabanı işlemlerini yönetir
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Veritabanı tabloları
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kitap - Yazar ilişkisi: Kitabı silen olunca yazarı silme (Restrict)
            // Bu sayede yazarı olan bir kitap varsa yazar silinemez
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Kitap - Kategori ilişkisi: Kitabı silen olunca kategoriyi silme (Restrict)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Başlangıç verilerini ekle (Seed Data)
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Yazar seed verileri
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FullName = "Sabahattin Ali",
                    BirthYear = 1907,
                    Country = "Türkiye",
                    Biography = "Türk yazar ve şair. Kürk Mantolu Madonna başta olmak üzere pek çok önemli eser kaleme almıştır."
                },
                new Author
                {
                    Id = 2,
                    FullName = "Yaşar Kemal",
                    BirthYear = 1923,
                    Country = "Türkiye",
                    Biography = "Nobel Edebiyat Ödülü'ne aday gösterilen Türk yazar. İnce Memed romanıyla dünya çapında ün kazanmıştır."
                },
                new Author
                {
                    Id = 3,
                    FullName = "George Orwell",
                    BirthYear = 1903,
                    Country = "Birleşik Krallık",
                    Biography = "İngiliz yazar ve gazeteci. 1984 ve Hayvan Çiftliği adlı distopik romanlarıyla tanınmaktadır."
                },
                new Author
                {
                    Id = 4,
                    FullName = "Halide Edib Adıvar",
                    BirthYear = 1884,
                    Country = "Türkiye",
                    Biography = "Türk romancı, milliyetçi ve feminist. Kurtuluş Savaşı'nın önemli isimlerinden biridir."
                }
            );

            // Kategori seed verileri
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Roman",
                    Description = "Uzun anlatı türündeki kurgu eserleri"
                },
                new Category
                {
                    Id = 2,
                    Name = "Siyasi Kurgu",
                    Description = "Siyasi temalar içeren kurgu eserleri"
                },
                new Category
                {
                    Id = 3,
                    Name = "Türk Edebiyatı",
                    Description = "Türk yazarların kaleme aldığı edebiyat eserleri"
                },
                new Category
                {
                    Id = 4,
                    Name = "Klasik Edebiyat",
                    Description = "Dünya edebiyatının klasik sayılan eserleri"
                }
            );

            // Kitap seed verileri
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Kürk Mantolu Madonna",
                    ISBN = "978-975-10-0001-1",
                    PublicationYear = 1943,
                    PageCount = 152,
                    ShelfLocation = "A-01",
                    IsAvailable = true,
                    AuthorId = 1,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 2,
                    Title = "İnce Memed",
                    ISBN = "978-975-10-0002-2",
                    PublicationYear = 1955,
                    PageCount = 408,
                    ShelfLocation = "A-02",
                    IsAvailable = true,
                    AuthorId = 2,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 3,
                    Title = "Hayvan Çiftliği",
                    ISBN = "978-975-10-0003-3",
                    PublicationYear = 1945,
                    PageCount = 112,
                    ShelfLocation = "B-01",
                    IsAvailable = false,
                    AuthorId = 3,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 4,
                    Title = "1984",
                    ISBN = "978-975-10-0004-4",
                    PublicationYear = 1949,
                    PageCount = 352,
                    ShelfLocation = "B-02",
                    IsAvailable = true,
                    AuthorId = 3,
                    CategoryId = 2
                },
                new Book
                {
                    Id = 5,
                    Title = "Sinekli Bakkal",
                    ISBN = "978-975-10-0005-5",
                    PublicationYear = 1936,
                    PageCount = 320,
                    ShelfLocation = "A-03",
                    IsAvailable = true,
                    AuthorId = 4,
                    CategoryId = 3
                }
            );
        }
    }
}
