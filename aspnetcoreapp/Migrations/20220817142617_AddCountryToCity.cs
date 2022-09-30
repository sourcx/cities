using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreApp.Migrations
{
    public partial class AddCountryToCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "City",
                type: "TEXT",
                nullable: false,
                defaultValue: string.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "City");
        }
    }
}
