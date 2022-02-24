using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManager.WebApi.Migrations
{
    public partial class UpdateAddSupplierid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSupplier",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSupplier",
                table: "Products");
        }
    }
}
