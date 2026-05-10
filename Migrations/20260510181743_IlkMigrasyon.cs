using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KutuphaneSistemi.Migrations
{
    /// <inheritdoc />
    public partial class IlkMigrasyon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: true),
                    ShelfLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BirthYear", "Country", "FullName" },
                values: new object[,]
                {
                    { 1, "Türk yazar ve şair. Kürk Mantolu Madonna başta olmak üzere pek çok önemli eser kaleme almıştır.", 1907, "Türkiye", "Sabahattin Ali" },
                    { 2, "Nobel Edebiyat Ödülü'ne aday gösterilen Türk yazar. İnce Memed romanıyla dünya çapında ün kazanmıştır.", 1923, "Türkiye", "Yaşar Kemal" },
                    { 3, "İngiliz yazar ve gazeteci. 1984 ve Hayvan Çiftliği adlı distopik romanlarıyla tanınmaktadır.", 1903, "Birleşik Krallık", "George Orwell" },
                    { 4, "Türk romancı, milliyetçi ve feminist. Kurtuluş Savaşı'nın önemli isimlerinden biridir.", 1884, "Türkiye", "Halide Edib Adıvar" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Uzun anlatı türündeki kurgu eserleri", "Roman" },
                    { 2, "Siyasi temalar içeren kurgu eserleri", "Siyasi Kurgu" },
                    { 3, "Türk yazarların kaleme aldığı edebiyat eserleri", "Türk Edebiyatı" },
                    { 4, "Dünya edebiyatının klasik sayılan eserleri", "Klasik Edebiyat" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "ISBN", "IsAvailable", "PageCount", "PublicationYear", "ShelfLocation", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, "978-975-10-0001-1", true, 152, 1943, "A-01", "Kürk Mantolu Madonna" },
                    { 2, 2, 3, "978-975-10-0002-2", true, 408, 1955, "A-02", "İnce Memed" },
                    { 3, 3, 2, "978-975-10-0003-3", false, 112, 1945, "B-01", "Hayvan Çiftliği" },
                    { 4, 3, 2, "978-975-10-0004-4", true, 352, 1949, "B-02", "1984" },
                    { 5, 4, 3, "978-975-10-0005-5", true, 320, 1936, "A-03", "Sinekli Bakkal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
