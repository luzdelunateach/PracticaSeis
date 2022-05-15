using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MakeOrderCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ProductPurchaseOrderCart",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchaseOrderCart", x => new { x.ProductsId, x.PurchaseOrderCartId });
                    table.ForeignKey(
                        name: "FK_ProductPurchaseOrderCart_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchaseOrderCart_PurchaseOrderCarts_PurchaseOrderCartId",
                        column: x => x.PurchaseOrderCartId,
                        principalTable: "PurchaseOrderCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseOrderCart_PurchaseOrderCartId",
                table: "ProductPurchaseOrderCart",
                column: "PurchaseOrderCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPurchaseOrderCart");

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
    }
}
