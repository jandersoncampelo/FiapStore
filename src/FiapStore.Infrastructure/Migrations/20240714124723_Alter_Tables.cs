using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appOrderItem_Orders_OrderId",
                table: "appOrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_appShoppers_ShopperId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Orders_OrderId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "appPayments");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "appOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_OrderId",
                table: "appPayments",
                newName: "IX_appPayments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShopperId",
                table: "appOrders",
                newName: "IX_appOrders_ShopperId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "appPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 14, 12, 47, 23, 260, DateTimeKind.Utc).AddTicks(5782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 13, 19, 13, 24, 227, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.AddPrimaryKey(
                name: "PK_appPayments",
                table: "appPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appOrders",
                table: "appOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appOrderItem_appOrders_OrderId",
                table: "appOrderItem",
                column: "OrderId",
                principalTable: "appOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appOrders_appShoppers_ShopperId",
                table: "appOrders",
                column: "ShopperId",
                principalTable: "appShoppers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appPayments_appOrders_OrderId",
                table: "appPayments",
                column: "OrderId",
                principalTable: "appOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appOrderItem_appOrders_OrderId",
                table: "appOrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_appOrders_appShoppers_ShopperId",
                table: "appOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_appPayments_appOrders_OrderId",
                table: "appPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appPayments",
                table: "appPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appOrders",
                table: "appOrders");

            migrationBuilder.RenameTable(
                name: "appPayments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "appOrders",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_appPayments_OrderId",
                table: "Payment",
                newName: "IX_Payment_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_appOrders_ShopperId",
                table: "Orders",
                newName: "IX_Orders_ShopperId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 13, 19, 13, 24, 227, DateTimeKind.Utc).AddTicks(2483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 14, 12, 47, 23, 260, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appOrderItem_Orders_OrderId",
                table: "appOrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_appShoppers_ShopperId",
                table: "Orders",
                column: "ShopperId",
                principalTable: "appShoppers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Orders_OrderId",
                table: "Payment",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
