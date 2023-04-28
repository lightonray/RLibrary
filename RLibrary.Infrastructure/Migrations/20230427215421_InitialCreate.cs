using Microsoft.EntityFrameworkCore.Migrations;

namespace RLibrary.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "genre",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "price",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    amount = table.Column<decimal>(type: "REAL", maxLength: 254, nullable: false),
                    currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shoppingcart",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    total_price = table.Column<decimal>(type: "REAL", nullable: false),
                    currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 2049, nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Quanitity = table.Column<int>(type: "INTEGER", nullable: false),
                    file_id = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    category_id = table.Column<int>(type: "INTEGER", nullable: false),
                    price_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_genre_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_price_price_id",
                        column: x => x.price_id,
                        principalSchema: "dbo",
                        principalTable: "price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingcart_item",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    book_id = table.Column<int>(type: "INTEGER", nullable: false),
                    price_id = table.Column<int>(type: "INTEGER", nullable: false),
                    shopping_cart_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingcart_item_book_book_id",
                        column: x => x.book_id,
                        principalSchema: "dbo",
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingcart_item_price_price_id",
                        column: x => x.price_id,
                        principalSchema: "dbo",
                        principalTable: "price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingcart_item_shoppingcart_shopping_cart_id",
                        column: x => x.shopping_cart_id,
                        principalSchema: "dbo",
                        principalTable: "shoppingcart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "genre",
                columns: new[] { "Id", "name" },
                values: new object[] { 1, "Other" });

            migrationBuilder.CreateIndex(
                name: "IX_book_category_id",
                schema: "dbo",
                table: "book",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_name",
                schema: "dbo",
                table: "book",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_price_id",
                schema: "dbo",
                table: "book",
                column: "price_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingcart_item_book_id",
                schema: "dbo",
                table: "shoppingcart_item",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingcart_item_price_id",
                schema: "dbo",
                table: "shoppingcart_item",
                column: "price_id");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingcart_item_shopping_cart_id",
                schema: "dbo",
                table: "shoppingcart_item",
                column: "shopping_cart_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingcart_item",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "book",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "shoppingcart",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "genre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "price",
                schema: "dbo");
        }
    }
}
