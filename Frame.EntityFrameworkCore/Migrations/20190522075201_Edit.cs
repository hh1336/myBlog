using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsMe",
                table: "ArticleComments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMe",
                table: "ArticleComments");
        }
    }
}
