using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MakeOrderCartDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPurchaseOrderCart");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PurchaseOrderCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseOrderCartDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderCartDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderCartDetails_PurchaseOrderCarts_PurchaseOrderCartId",
                        column: x => x.PurchaseOrderCartId,
                        principalTable: "PurchaseOrderCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderCarts_ProductId",
                table: "PurchaseOrderCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderCartDetails_PurchaseOrderCartId",
                table: "PurchaseOrderCartDetails",
                column: "PurchaseOrderCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderCarts_Products_ProductId",
                table: "PurchaseOrderCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderCarts_Products_ProductId",
                table: "PurchaseOrderCarts");

            migrationBuilder.DropTable(
                name: "PurchaseOrderCartDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderCarts_ProductId",
                table: "PurchaseOrderCarts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseOrderCarts");

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
    }
}
