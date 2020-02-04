using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backendproject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<int>(nullable: false),
                    IngridientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<int>(nullable: false),
                    Burger = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BongsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    IngridientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BongsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BongsDetails_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BongsDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    created = table.Column<DateTime>(nullable: false),
                    BongDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bongs_BongsDetails_BongDetailsId",
                        column: x => x.BongDetailsId,
                        principalTable: "BongsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bongs",
                columns: new[] { "Id", "BongDetailsId", "created" },
                values: new object[] { 1, null, new DateTime(2020, 1, 16, 16, 44, 30, 844, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "IngridientName", "Price" },
                values: new object[] { 1, "Salad", 1 });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "IngridientName", "Price" },
                values: new object[] { 2, "Cheese", 2 });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "IngridientName", "Price" },
                values: new object[] { 3, "Bacon", 3 });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "IngridientName", "Price" },
                values: new object[] { 4, "Meat", 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Burger", "Price" },
                values: new object[] { 1, "Burger", 50 });

            migrationBuilder.InsertData(
                table: "BongsDetails",
                columns: new[] { "Id", "IngridientId", "ProductId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "BongsDetails",
                columns: new[] { "Id", "IngridientId", "ProductId" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bongs_BongDetailsId",
                table: "Bongs",
                column: "BongDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BongsDetails_IngridientId",
                table: "BongsDetails",
                column: "IngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_BongsDetails_ProductId",
                table: "BongsDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bongs");

            migrationBuilder.DropTable(
                name: "BongsDetails");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
