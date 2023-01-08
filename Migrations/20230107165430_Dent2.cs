using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dent.Migrations
{
    public partial class Dent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "data",
                table: "Form",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckDoctor",
                value: new DateTime(2003, 1, 7, 19, 54, 29, 890, DateTimeKind.Local).AddTicks(8352));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "data",
                table: "Form",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckDoctor",
                value: new DateTime(2003, 1, 7, 18, 29, 33, 51, DateTimeKind.Local).AddTicks(4563));
        }
    }
}
