using Microsoft.EntityFrameworkCore.Migrations;

namespace tadbir.Data.Migrations
{
    public partial class invoicerowid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "InvoiceRow",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceRow_InvoiceId",
                table: "InvoiceRow",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceRow_InvoiceId",
                table: "InvoiceRow");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InvoiceRow");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow",
                columns: new[] { "InvoiceId", "ProductId" });
        }
    }
}
