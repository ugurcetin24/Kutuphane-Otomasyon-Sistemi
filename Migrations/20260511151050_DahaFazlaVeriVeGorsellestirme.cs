using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KutuphaneSistemi.Migrations
{
    /// <inheritdoc />
    public partial class DahaFazlaVeriVeGorsellestirme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BirthYear", "Country", "FullName" },
                values: new object[,]
                {
                    { 5, "Nobel Edebiyat Ödülü sahibi Türk yazar. Benim Adım Kırmızı ve Kar başlıca eserleri arasındadır.", 1952, "Türkiye", "Orhan Pamuk" },
                    { 6, "Rus edebiyatının büyük ustalarından biri. Suç ve Ceza ile Karamazov Kardeşler başyapıtlarıdır.", 1821, "Rusya", "Fyodor Dostoyevski" },
                    { 7, "Varoluşçu ve absürd edebiyatın öncüsü. Dönüşüm ve Dava en çok okunan eserleridir.", 1883, "Avusturya-Macaristan", "Franz Kafka" },
                    { 8, "Fransız romantizm akımının önde gelen yazarı. Sefiller ve Notre-Dame'ın Kamburu başlıca eserleridir.", 1802, "Fransa", "Victor Hugo" },
                    { 9, "Avusturyalı yazar. Psikolojik derinliğiyle tanınan Satranç ve kısa hikayeleriyle ünlüdür.", 1881, "Avusturya", "Stefan Zweig" },
                    { 10, "İngiliz romancı. Toplumsal eleştiri ve ince mizahıyla Gurur ve Önyargı başyapıt kabul edilir.", 1775, "Birleşik Krallık", "Jane Austen" },
                    { 11, "İngiliz yazar. Harry Potter serisiyle dünya çapında milyonlarca okuyucuya ulaşmıştır.", 1965, "Birleşik Krallık", "J.K. Rowling" },
                    { 12, "Victorian dönem İngilteresi'ni anlatan romanlarıyla tanınan İngiliz yazar. Oliver Twist ve İki Şehrin Hikayesi önemli eserleridir.", 1812, "Birleşik Krallık", "Charles Dickens" },
                    { 13, "Amerikalı yazar. Jazz Çağı'nı en iyi anlatan roman olan Büyük Gatsby'nin yazarıdır.", 1896, "Amerika Birleşik Devletleri", "F. Scott Fitzgerald" },
                    { 14, "Amerikalı yazar ve sosyalist aktivist. Doğa ve hayatta kalma temalarını işleyen Martin Eden ve Vahşetin Çağrısı önemli eserleridir.", 1876, "Amerika Birleşik Devletleri", "Jack London" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "ISBN", "IsAvailable", "PageCount", "PublicationYear", "ShelfLocation", "Title" },
                values: new object[] { 6, 1, 3, "978-975-10-0006-6", true, 200, 1940, "A-04", "İçimizdeki Şeytan" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 5, "Farklı ülkelerden dünya edebiyatına mal olmuş başyapıtlar", "Dünya Klasikleri" },
                    { 6, "İnsan psikolojisini ve iç dünyasını ön plana çıkaran eserler", "Psikoloji" },
                    { 7, "Büyü, mitoloji ve hayali dünyaları konu alan eserler", "Fantezi" },
                    { 8, "Tarihsel olayları ve dönemleri anlatan eserler", "Tarih" },
                    { 9, "Duygusal yoğunluğu ve insani çatışmaları ele alan eserler", "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "ISBN", "IsAvailable", "PageCount", "PublicationYear", "ShelfLocation", "Title" },
                values: new object[,]
                {
                    { 7, 5, 3, "978-975-10-0007-7", false, 417, 1998, "A-05", "Benim Adım Kırmızı" },
                    { 8, 5, 1, "978-975-10-0008-8", true, 479, 2002, "A-06", "Kar" },
                    { 9, 6, 5, "978-975-10-0009-9", true, 671, 1866, "C-01", "Suç ve Ceza" },
                    { 10, 6, 5, "978-975-10-0010-0", false, 924, 1880, "C-02", "Karamazov Kardeşler" },
                    { 11, 6, 5, "978-975-10-0011-1", true, 144, 1848, "C-03", "Beyaz Geceler" },
                    { 12, 7, 5, "978-975-10-0012-2", true, 192, 1925, "C-04", "Dava" },
                    { 13, 7, 5, "978-975-10-0013-3", false, 96, 1915, "C-05", "Dönüşüm" },
                    { 14, 8, 5, "978-975-10-0014-4", true, 1232, 1862, "D-01", "Sefiller" },
                    { 15, 8, 5, "978-975-10-0015-5", true, 536, 1831, "D-02", "Notre-Dame'ın Kamburu" },
                    { 16, 9, 5, "978-975-10-0016-6", true, 128, 1942, "D-03", "Satranç" },
                    { 17, 9, 9, "978-975-10-0017-7", false, 80, 1922, "D-04", "Bilinmeyen Bir Kadının Mektubu" },
                    { 18, 10, 5, "978-975-10-0018-8", true, 432, 1813, "E-01", "Gurur ve Önyargı" },
                    { 19, 10, 1, "978-975-10-0019-9", true, 474, 1815, "E-02", "Emma" },
                    { 20, 11, 7, "978-975-10-0020-0", false, 223, 1997, "E-03", "Harry Potter ve Felsefe Taşı" },
                    { 21, 11, 7, "978-975-10-0021-1", true, 251, 1998, "E-04", "Harry Potter ve Sırlar Odası" },
                    { 22, 12, 5, "978-975-10-0022-2", true, 448, 1859, "E-05", "İki Şehrin Hikayesi" },
                    { 23, 13, 5, "978-975-10-0023-3", false, 180, 1925, "F-01", "Büyük Gatsby" },
                    { 24, 14, 5, "978-975-10-0024-4", true, 411, 1909, "F-02", "Martin Eden" },
                    { 25, 14, 1, "978-975-10-0025-5", true, 172, 1903, "F-03", "Vahşetin Çağrısı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
