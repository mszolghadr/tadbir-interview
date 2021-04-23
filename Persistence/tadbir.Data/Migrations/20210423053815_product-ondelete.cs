using Microsoft.EntityFrameworkCore.Migrations;

namespace tadbir.Data.Migrations
{
    public partial class productondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRow_Products_ProductId",
                table: "InvoiceRow");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRow_Products_ProductId",
                table: "InvoiceRow",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRow_Products_ProductId",
                table: "InvoiceRow");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRow_Products_ProductId",
                table: "InvoiceRow",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
