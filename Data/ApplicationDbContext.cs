using KutuphaneSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneSistemi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // ================================================================
            // YAZARLAR
            // ================================================================
            modelBuilder.Entity<Author>().HasData(
                // Mevcut yazarlar (değiştirilmedi)
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
                },
                // Yeni yazarlar
                new Author
                {
                    Id = 5,
                    FullName = "Orhan Pamuk",
                    BirthYear = 1952,
                    Country = "Türkiye",
                    Biography = "Nobel Edebiyat Ödülü sahibi Türk yazar. Benim Adım Kırmızı ve Kar başlıca eserleri arasındadır."
                },
                new Author
                {
                    Id = 6,
                    FullName = "Fyodor Dostoyevski",
                    BirthYear = 1821,
                    Country = "Rusya",
                    Biography = "Rus edebiyatının büyük ustalarından biri. Suç ve Ceza ile Karamazov Kardeşler başyapıtlarıdır."
                },
                new Author
                {
                    Id = 7,
                    FullName = "Franz Kafka",
                    BirthYear = 1883,
                    Country = "Avusturya-Macaristan",
                    Biography = "Varoluşçu ve absürd edebiyatın öncüsü. Dönüşüm ve Dava en çok okunan eserleridir."
                },
                new Author
                {
                    Id = 8,
                    FullName = "Victor Hugo",
                    BirthYear = 1802,
                    Country = "Fransa",
                    Biography = "Fransız romantizm akımının önde gelen yazarı. Sefiller ve Notre-Dame'ın Kamburu başlıca eserleridir."
                },
                new Author
                {
                    Id = 9,
                    FullName = "Stefan Zweig",
                    BirthYear = 1881,
                    Country = "Avusturya",
                    Biography = "Avusturyalı yazar. Psikolojik derinliğiyle tanınan Satranç ve kısa hikayeleriyle ünlüdür."
                },
                new Author
                {
                    Id = 10,
                    FullName = "Jane Austen",
                    BirthYear = 1775,
                    Country = "Birleşik Krallık",
                    Biography = "İngiliz romancı. Toplumsal eleştiri ve ince mizahıyla Gurur ve Önyargı başyapıt kabul edilir."
                },
                new Author
                {
                    Id = 11,
                    FullName = "J.K. Rowling",
                    BirthYear = 1965,
                    Country = "Birleşik Krallık",
                    Biography = "İngiliz yazar. Harry Potter serisiyle dünya çapında milyonlarca okuyucuya ulaşmıştır."
                },
                new Author
                {
                    Id = 12,
                    FullName = "Charles Dickens",
                    BirthYear = 1812,
                    Country = "Birleşik Krallık",
                    Biography = "Victorian dönem İngilteresi'ni anlatan romanlarıyla tanınan İngiliz yazar. Oliver Twist ve İki Şehrin Hikayesi önemli eserleridir."
                },
                new Author
                {
                    Id = 13,
                    FullName = "F. Scott Fitzgerald",
                    BirthYear = 1896,
                    Country = "Amerika Birleşik Devletleri",
                    Biography = "Amerikalı yazar. Jazz Çağı'nı en iyi anlatan roman olan Büyük Gatsby'nin yazarıdır."
                },
                new Author
                {
                    Id = 14,
                    FullName = "Jack London",
                    BirthYear = 1876,
                    Country = "Amerika Birleşik Devletleri",
                    Biography = "Amerikalı yazar ve sosyalist aktivist. Doğa ve hayatta kalma temalarını işleyen Martin Eden ve Vahşetin Çağrısı önemli eserleridir."
                }
            );

            // ================================================================
            // KATEGORİLER
            // ================================================================
            modelBuilder.Entity<Category>().HasData(
                // Mevcut kategoriler (değiştirilmedi)
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
                },
                // Yeni kategoriler
                new Category
                {
                    Id = 5,
                    Name = "Dünya Klasikleri",
                    Description = "Farklı ülkelerden dünya edebiyatına mal olmuş başyapıtlar"
                },
                new Category
                {
                    Id = 6,
                    Name = "Psikoloji",
                    Description = "İnsan psikolojisini ve iç dünyasını ön plana çıkaran eserler"
                },
                new Category
                {
                    Id = 7,
                    Name = "Fantezi",
                    Description = "Büyü, mitoloji ve hayali dünyaları konu alan eserler"
                },
                new Category
                {
                    Id = 8,
                    Name = "Tarih",
                    Description = "Tarihsel olayları ve dönemleri anlatan eserler"
                },
                new Category
                {
                    Id = 9,
                    Name = "Drama",
                    Description = "Duygusal yoğunluğu ve insani çatışmaları ele alan eserler"
                }
            );

            // ================================================================
            // KİTAPLAR
            // ================================================================
            modelBuilder.Entity<Book>().HasData(
                // Mevcut kitaplar (değiştirilmedi)
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
                },
                // Yeni kitaplar
                new Book
                {
                    Id = 6,
                    Title = "İçimizdeki Şeytan",
                    ISBN = "978-975-10-0006-6",
                    PublicationYear = 1940,
                    PageCount = 200,
                    ShelfLocation = "A-04",
                    IsAvailable = true,
                    AuthorId = 1,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 7,
                    Title = "Benim Adım Kırmızı",
                    ISBN = "978-975-10-0007-7",
                    PublicationYear = 1998,
                    PageCount = 417,
                    ShelfLocation = "A-05",
                    IsAvailable = false,
                    AuthorId = 5,
                    CategoryId = 3
                },
                new Book
                {
                    Id = 8,
                    Title = "Kar",
                    ISBN = "978-975-10-0008-8",
                    PublicationYear = 2002,
                    PageCount = 479,
                    ShelfLocation = "A-06",
                    IsAvailable = true,
                    AuthorId = 5,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 9,
                    Title = "Suç ve Ceza",
                    ISBN = "978-975-10-0009-9",
                    PublicationYear = 1866,
                    PageCount = 671,
                    ShelfLocation = "C-01",
                    IsAvailable = true,
                    AuthorId = 6,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 10,
                    Title = "Karamazov Kardeşler",
                    ISBN = "978-975-10-0010-0",
                    PublicationYear = 1880,
                    PageCount = 924,
                    ShelfLocation = "C-02",
                    IsAvailable = false,
                    AuthorId = 6,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 11,
                    Title = "Beyaz Geceler",
                    ISBN = "978-975-10-0011-1",
                    PublicationYear = 1848,
                    PageCount = 144,
                    ShelfLocation = "C-03",
                    IsAvailable = true,
                    AuthorId = 6,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 12,
                    Title = "Dava",
                    ISBN = "978-975-10-0012-2",
                    PublicationYear = 1925,
                    PageCount = 192,
                    ShelfLocation = "C-04",
                    IsAvailable = true,
                    AuthorId = 7,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 13,
                    Title = "Dönüşüm",
                    ISBN = "978-975-10-0013-3",
                    PublicationYear = 1915,
                    PageCount = 96,
                    ShelfLocation = "C-05",
                    IsAvailable = false,
                    AuthorId = 7,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 14,
                    Title = "Sefiller",
                    ISBN = "978-975-10-0014-4",
                    PublicationYear = 1862,
                    PageCount = 1232,
                    ShelfLocation = "D-01",
                    IsAvailable = true,
                    AuthorId = 8,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 15,
                    Title = "Notre-Dame'ın Kamburu",
                    ISBN = "978-975-10-0015-5",
                    PublicationYear = 1831,
                    PageCount = 536,
                    ShelfLocation = "D-02",
                    IsAvailable = true,
                    AuthorId = 8,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 16,
                    Title = "Satranç",
                    ISBN = "978-975-10-0016-6",
                    PublicationYear = 1942,
                    PageCount = 128,
                    ShelfLocation = "D-03",
                    IsAvailable = true,
                    AuthorId = 9,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 17,
                    Title = "Bilinmeyen Bir Kadının Mektubu",
                    ISBN = "978-975-10-0017-7",
                    PublicationYear = 1922,
                    PageCount = 80,
                    ShelfLocation = "D-04",
                    IsAvailable = false,
                    AuthorId = 9,
                    CategoryId = 9
                },
                new Book
                {
                    Id = 18,
                    Title = "Gurur ve Önyargı",
                    ISBN = "978-975-10-0018-8",
                    PublicationYear = 1813,
                    PageCount = 432,
                    ShelfLocation = "E-01",
                    IsAvailable = true,
                    AuthorId = 10,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 19,
                    Title = "Emma",
                    ISBN = "978-975-10-0019-9",
                    PublicationYear = 1815,
                    PageCount = 474,
                    ShelfLocation = "E-02",
                    IsAvailable = true,
                    AuthorId = 10,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 20,
                    Title = "Harry Potter ve Felsefe Taşı",
                    ISBN = "978-975-10-0020-0",
                    PublicationYear = 1997,
                    PageCount = 223,
                    ShelfLocation = "E-03",
                    IsAvailable = false,
                    AuthorId = 11,
                    CategoryId = 7
                },
                new Book
                {
                    Id = 21,
                    Title = "Harry Potter ve Sırlar Odası",
                    ISBN = "978-975-10-0021-1",
                    PublicationYear = 1998,
                    PageCount = 251,
                    ShelfLocation = "E-04",
                    IsAvailable = true,
                    AuthorId = 11,
                    CategoryId = 7
                },
                new Book
                {
                    Id = 22,
                    Title = "İki Şehrin Hikayesi",
                    ISBN = "978-975-10-0022-2",
                    PublicationYear = 1859,
                    PageCount = 448,
                    ShelfLocation = "E-05",
                    IsAvailable = true,
                    AuthorId = 12,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 23,
                    Title = "Büyük Gatsby",
                    ISBN = "978-975-10-0023-3",
                    PublicationYear = 1925,
                    PageCount = 180,
                    ShelfLocation = "F-01",
                    IsAvailable = false,
                    AuthorId = 13,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 24,
                    Title = "Martin Eden",
                    ISBN = "978-975-10-0024-4",
                    PublicationYear = 1909,
                    PageCount = 411,
                    ShelfLocation = "F-02",
                    IsAvailable = true,
                    AuthorId = 14,
                    CategoryId = 5
                },
                new Book
                {
                    Id = 25,
                    Title = "Vahşetin Çağrısı",
                    ISBN = "978-975-10-0025-5",
                    PublicationYear = 1903,
                    PageCount = 172,
                    ShelfLocation = "F-03",
                    IsAvailable = true,
                    AuthorId = 14,
                    CategoryId = 1
                }
            );
        }
    }
}
