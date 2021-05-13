using Microsoft.EntityFrameworkCore.Migrations;

namespace ToantvOrderManageNetCore.Migrations
{
    public partial class editvender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOrder_Vender_VendorId",
                table: "CompanyOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vender",
                table: "Vender");

            migrationBuilder.RenameTable(
                name: "Vender",
                newName: "Vendor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "VenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOrder_Vendor_VendorId",
                table: "CompanyOrder",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "VenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOrder_Vendor_VendorId",
                table: "CompanyOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vender",
                table: "Vender",
                column: "VenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOrder_Vender_VendorId",
                table: "CompanyOrder",
                column: "VendorId",
                principalTable: "Vender",
                principalColumn: "VenderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
