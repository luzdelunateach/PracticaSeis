using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MakeCantidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "PurchaseOrderProviderDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "PurchaseOrderProviderDetails");
        }
    }
}
