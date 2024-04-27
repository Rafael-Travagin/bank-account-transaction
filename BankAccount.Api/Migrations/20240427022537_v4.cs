using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccount.Api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 2, 25, 37, 327, DateTimeKind.Utc).AddTicks(3728),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 4, 27, 0, 16, 43, 325, DateTimeKind.Utc).AddTicks(3802));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 0, 16, 43, 325, DateTimeKind.Utc).AddTicks(3802),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 4, 27, 2, 25, 37, 327, DateTimeKind.Utc).AddTicks(3728));
        }
    }
}
