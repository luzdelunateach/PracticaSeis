using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MakePurchaseOrdersProviderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PurchaseOrderCarts_PurchaseOrderCartId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PurchaseOrderProviders_PurchaseOrderProviderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseOrderCartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseOrderProviderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderProviderId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderProviderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderProviderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderProviderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProviderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProviderDetails_PurchaseOrderCarts_PurchaseOrderCartId",
                        column: x => x.PurchaseOrderCartId,
                        principalTable: "PurchaseOrderCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProviderDetails_PurchaseOrderProviders_PurchaseOrderProviderId",
                        column: x => x.PurchaseOrderProviderId,
                        principalTable: "PurchaseOrderProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProviderDetails_ProductId",
                table: "PurchaseOrderProviderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProviderDetails_PurchaseOrderCartId",
                table: "PurchaseOrderProviderDetails",
                column: "PurchaseOrderCartId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProviderDetails_PurchaseOrderProviderId",
                table: "PurchaseOrderProviderDetails",
                column: "PurchaseOrderProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderProviderDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderCartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderProviderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseOrderCartId",
                table: "Products",
                column: "PurchaseOrderCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseOrderProviderId",
                table: "Products",
                column: "PurchaseOrderProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PurchaseOrderCarts_PurchaseOrderCartId",
                table: "Products",
                column: "PurchaseOrderCartId",
                principalTable: "PurchaseOrderCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PurchaseOrderProviders_PurchaseOrderProviderId",
                table: "Products",
                column: "PurchaseOrderProviderId",
                principalTable: "PurchaseOrderProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
