using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class AddArticleEntitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Introduce",
                table: "UserInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classifies",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AdminMenuId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classifies_AdminMenu_AdminMenuId",
                        column: x => x.AdminMenuId,
                        principalTable: "AdminMenu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveMessages",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    LeaveTime = table.Column<DateTime>(nullable: false),
                    MessAge = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    SortDel = table.Column<int>(nullable: false),
                    ContactInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveMessages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<byte[]>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<byte[]>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: true),
                    DelUser = table.Column<byte[]>(nullable: true),
                    SortDel = table.Column<int>(nullable: false),
                    AcName = table.Column<string>(nullable: true),
                    Like = table.Column<long>(nullable: false),
                    ContentKey = table.Column<string>(nullable: true),
                    ClassifyId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articles_Classifies_ClassifyId",
                        column: x => x.ClassifyId,
                        principalTable: "Classifies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SortDel = table.Column<int>(nullable: false),
                    ContactInformation = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    ArticleId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    ArticleId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "ArticleImages",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ClassifyId",
                table: "Articles",
                column: "ClassifyId");

            migrationBuilder.CreateIndex(
                name: "IX_Classifies_AdminMenuId",
                table: "Classifies",
                column: "AdminMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "LeaveMessages");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Classifies");

            migrationBuilder.DropColumn(
                name: "Introduce",
                table: "UserInfos");
        }
    }
}
