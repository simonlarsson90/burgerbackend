using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backendproject.Migrations
{
    public partial class cors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bongs",
                keyColumn: "Id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2020, 1, 21, 14, 9, 14, 164, DateTimeKind.Local).AddTicks(8170));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bongs",
                keyColumn: "Id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2020, 1, 21, 11, 37, 13, 16, DateTimeKind.Local).AddTicks(1160));
        }
    }
}
