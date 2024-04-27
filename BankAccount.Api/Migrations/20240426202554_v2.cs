using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccount.Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transaction",
                type: "NVARCHAR(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 26, 20, 25, 54, 353, DateTimeKind.Utc).AddTicks(440),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 4, 25, 3, 17, 12, 502, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transaction",
                type: "Decimal(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transaction",
                type: "NVARCHAR(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(10)",
                oldMaxLength: 10,
                oldDefaultValue: "Active");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 3, 17, 12, 502, DateTimeKind.Utc).AddTicks(2720),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 4, 26, 20, 25, 54, 353, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transaction",
                type: "Decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,0)",
                oldDefaultValue: 0m);
        }
    }
}
