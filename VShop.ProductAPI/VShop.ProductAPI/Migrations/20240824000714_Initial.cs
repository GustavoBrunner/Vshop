using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    PK_category_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.PK_category_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    PK_product_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stock = table.Column<long>(type: "bigint", nullable: false, defaultValue: 100L),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_category_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.PK_product_id);
                    table.ForeignKey(
                        name: "FK_products_categories_FK_category_id",
                        column: x => x.FK_category_id,
                        principalTable: "categories",
                        principalColumn: "PK_category_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "PK_category_id", "category_name" },
                values: new object[] { "3255b7f7-ec73-4911-8429-69f8dac47872", "Food" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "PK_category_id", "category_name" },
                values: new object[] { "7e054430-8cd7-4615-9b46-545ad98faf55", "Scholar material" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "PK_category_id", "category_name" },
                values: new object[] { "dcb1eea1-34f2-4043-b6c4-d3f53ea78b79", "Clothes" });

            migrationBuilder.CreateIndex(
                name: "IX_products_FK_category_id",
                table: "products",
                column: "FK_category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
