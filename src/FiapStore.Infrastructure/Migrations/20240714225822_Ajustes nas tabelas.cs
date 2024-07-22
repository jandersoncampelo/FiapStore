using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ajustesnastabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appBasket_appShoppers_Id",
                table: "appBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_appOrders_appShoppers_ShopperId",
                table: "appOrders");

            migrationBuilder.DropTable(
                name: "appShoppers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "appBasketItem");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "appBasketItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "appPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 14, 22, 58, 21, 746, DateTimeKind.Utc).AddTicks(2339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 14, 12, 47, 23, 260, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "appBasket",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "appCustomer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appCustomer", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_appBasket_appCustomer_Id",
                table: "appBasket",
                column: "Id",
                principalTable: "appCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appOrders_appCustomer_ShopperId",
                table: "appOrders",
                column: "ShopperId",
                principalTable: "appCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appBasket_appCustomer_Id",
                table: "appBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_appOrders_appCustomer_ShopperId",
                table: "appOrders");

            migrationBuilder.DropTable(
                name: "appCustomer");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "appBasket");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "appPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 14, 12, 47, 23, 260, DateTimeKind.Utc).AddTicks(5782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 14, 22, 58, 21, 746, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "appBasketItem",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "appBasketItem",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "appShoppers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appShoppers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_appBasket_appShoppers_Id",
                table: "appBasket",
                column: "Id",
                principalTable: "appShoppers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appOrders_appShoppers_ShopperId",
                table: "appOrders",
                column: "ShopperId",
                principalTable: "appShoppers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
