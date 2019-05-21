using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class AddLikeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikeArticles",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    IP = table.Column<string>(nullable: true),
                    LikeTime = table.Column<DateTime>(nullable: false),
                    ArticleId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeArticles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LikeArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeArticles_ArticleId",
                table: "LikeArticles",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeArticles");
        }
    }
}
