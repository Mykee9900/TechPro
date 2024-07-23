﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPro.Migrations
{
    /// <inheritdoc />
    public partial class updatingShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CartItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "ShoppingCarts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "SessionID",
                table: "ShoppingCarts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "CartItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "CartItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItem",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "ShoppingCarts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CartItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
