using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MakePurchaseCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderProviderDetails_PurchaseOrderCarts_PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderProviderDetails_PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderCartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseOrderCartId",
                table: "Products",
                column: "PurchaseOrderCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PurchaseOrderCarts_PurchaseOrderCartId",
                table: "Products",
                column: "PurchaseOrderCartId",
                principalTable: "PurchaseOrderCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PurchaseOrderCarts_PurchaseOrderCartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseOrderCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderCartId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProviderDetails_PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails",
                column: "PurchaseOrderCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderProviderDetails_PurchaseOrderCarts_PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails",
                column: "PurchaseOrderCartId",
                principalTable: "PurchaseOrderCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
