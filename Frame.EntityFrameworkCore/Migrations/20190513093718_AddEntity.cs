using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class AddEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMenus",
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
                    MenuName = table.Column<string>(nullable: true),
                    ShowName = table.Column<string>(nullable: true),
                    IconAddress = table.Column<string>(nullable: true),
                    LinkAddress = table.Column<string>(nullable: true),
                    SortNumber = table.Column<int>(nullable: false),
                    IsShow = table.Column<int>(nullable: false),
                    IsSystemDefault = table.Column<int>(nullable: false),
                    Pid = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdminMenus_AdminMenus_Pid",
                        column: x => x.Pid,
                        principalTable: "AdminMenus",
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
                name: "Role",
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
                    RoleName = table.Column<string>(nullable: true),
                    RoleState = table.Column<int>(nullable: false),
                    IsSystemDefault = table.Column<int>(nullable: false),
                    Describe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    SortDel = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Introduce = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.ID);
                });

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
                        name: "FK_Classifies_AdminMenus_AdminMenuId",
                        column: x => x.AdminMenuId,
                        principalTable: "AdminMenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
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
                    AccountNumber = table.Column<string>(maxLength: 6, nullable: false),
                    PassWord = table.Column<string>(nullable: false),
                    AccountState = table.Column<int>(nullable: false),
                    OldPassWord = table.Column<string>(nullable: true),
                    UserInfoId = table.Column<byte[]>(nullable: true),
                    LoginCount = table.Column<int>(nullable: false),
                    LastLoginIp = table.Column<string>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AccountRole",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    AccountId = table.Column<byte[]>(nullable: true),
                    RoleId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountRole_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    RoleId = table.Column<byte[]>(nullable: true),
                    MenuId = table.Column<byte[]>(nullable: true),
                    AccountId = table.Column<byte[]>(nullable: true),
                    ActionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permission_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_AdminMenus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "AdminMenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
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
                name: "IX_AccountRole_AccountId",
                table: "AccountRole",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_RoleId",
                table: "AccountRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserInfoId",
                table: "Accounts",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMenus_Pid",
                table: "AdminMenus",
                column: "Pid");

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

            migrationBuilder.CreateIndex(
                name: "IX_Permission_AccountId",
                table: "Permission",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_MenuId",
                table: "Permission",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRole");

            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "LeaveMessages");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Classifies");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "AdminMenus");
        }
    }
}
