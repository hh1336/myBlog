using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class AddPermissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastLoginIp",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdminMenu",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: true),
                    DelUser = table.Column<string>(nullable: true),
                    SortDel = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    ShowName = table.Column<string>(nullable: true),
                    IconAddress = table.Column<string>(nullable: true),
                    LinkAddress = table.Column<string>(nullable: true),
                    SortNumber = table.Column<int>(nullable: false),
                    IsShow = table.Column<int>(nullable: false),
                    IsSystemDefault = table.Column<int>(nullable: false),
                    Pid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdminMenu_AdminMenu_Pid",
                        column: x => x.Pid,
                        principalTable: "AdminMenu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: true),
                    DelUser = table.Column<string>(nullable: true),
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
                name: "AccountRole",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true)
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
                    ID = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    MenuId = table.Column<Guid>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: true),
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
                        name: "FK_Permission_AdminMenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "AdminMenu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
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
                name: "IX_AdminMenu_Pid",
                table: "AdminMenu",
                column: "Pid");

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
                name: "Permission");

            migrationBuilder.DropTable(
                name: "AdminMenu");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropColumn(
                name: "LastLoginIp",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "Accounts");
        }
    }
}
