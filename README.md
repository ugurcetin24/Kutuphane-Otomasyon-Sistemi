# Kütüphane Otomasyon Sistemi

ASP.NET Core MVC 9 ile geliştirilmiş, kitap, yazar ve kategori yönetimi sağlayan bir kütüphane otomasyon uygulaması.

## Özellikler

- **Kitap Yönetimi** — Ekleme, düzenleme, silme, listeleme; ISBN, yayın yılı, sayfa sayısı, raf konumu ve müsaitlik durumu takibi
- **Yazar Yönetimi** — Ad soyad, doğum yılı, ülke ve biyografi bilgileri
- **Kategori Yönetimi** — Kategori adı ve açıklaması
- Kitaplar ile yazar/kategori arasında ilişkisel veri yapısı (One-to-Many)

## Teknolojiler

| Katman | Teknoloji |
|---|---|
| Framework | ASP.NET Core MVC 9 |
| ORM | Entity Framework Core 9 |
| Veritabanı | SQL Server (LocalDB) |
| UI | Bootstrap 5, jQuery |

## Kurulum

### Gereksinimler

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9)
- SQL Server veya SQL Server Express (LocalDB yeterli)

### Adımlar

```bash
# Repoyu klonla
git clone https://github.com/ugurcetin24/Kutuphane-Otomasyon-Sistemi.git
cd Kutuphane-Otomasyon-Sistemi

# Veritabanını oluştur
dotnet ef database update

# Uygulamayı çalıştır
dotnet run
```

Uygulama varsayılan olarak `https://localhost:5011` adresinde çalışır.

## Proje Yapısı

```
├── Controllers/        # MVC controller'lar
├── Data/               # DbContext
├── Migrations/         # EF Core migration dosyaları
├── Models/             # Veri modelleri (Book, Author, Category)
├── Views/              # Razor view'lar
└── wwwroot/            # Statik dosyalar (CSS, JS)
```

## Veritabanı Modeli

```
Author ──< Book >── Category
```

Her kitap bir yazara ve bir kategoriye aittir.
