using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace toanDemoApi.Migrations
{
    public partial class create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Vender",
                columns: table => new
                {
                    VenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vender", x => x.VenderId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalOrderNo = table.Column<string>(nullable: true),
                    ExternalOrderNo = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOrder", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_CompanyOrder_Vender_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vender",
                        principalColumn: "VenderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_CompanyOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "CompanyOrder",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOrder_VendorId",
                table: "CompanyOrder",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CategoryId",
                table: "OrderItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CompanyOrder");

            migrationBuilder.DropTable(
                name: "Vender");
        }
    }
}
