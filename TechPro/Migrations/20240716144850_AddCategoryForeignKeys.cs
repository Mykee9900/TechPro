using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPro.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "NetworkPackage",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageName = table.Column<string>(type: "TEXT", nullable: false),
                    PackageDescription = table.Column<string>(type: "TEXT", nullable: false),
                    PackagePrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkPackage", x => x.PackageID);
                });

            migrationBuilder.CreateTable(
                name: "NetworkTypes",
                columns: table => new
                {
                    NetworkTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NetworkTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkTypes", x => x.NetworkTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatBox",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MessageStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBox", x => x.ChatID);
                    table.ForeignKey(
                        name: "FK_ChatBox_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderSTatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_Purchases_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemID);
                    table.ForeignKey(
                        name: "FK_CartItems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_CartID",
                        column: x => x.CartID,
                        principalTable: "ShoppingCarts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventID);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    PackageProductID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => x.PackageProductID);
                    table.ForeignKey(
                        name: "FK_PackageProduct_NetworkPackage_PackageID",
                        column: x => x.PackageID,
                        principalTable: "NetworkPackage",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    PurchaseItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PurchaseID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.PurchaseItemID);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatBox_CustomerID",
                table: "ChatBox",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductID",
                table: "Inventory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_PackageID",
                table: "PackageProduct",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductID",
                table: "PackageProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductID",
                table: "PurchaseItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseID",
                table: "PurchaseItems",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerID",
                table: "Purchases",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ChatBox");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "NetworkTypes");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "NetworkPackage");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
