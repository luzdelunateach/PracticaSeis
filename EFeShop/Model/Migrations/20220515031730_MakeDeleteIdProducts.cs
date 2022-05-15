using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MakeDeleteIdProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderCarts_Products_ProductId",
                table: "PurchaseOrderCarts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderCarts_ProductId",
                table: "PurchaseOrderCarts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseOrderCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PurchaseOrderCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderCarts_ProductId",
                table: "PurchaseOrderCarts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderCarts_Products_ProductId",
                table: "PurchaseOrderCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
