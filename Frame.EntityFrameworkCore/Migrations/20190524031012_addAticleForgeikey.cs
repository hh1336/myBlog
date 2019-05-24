using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class addAticleForgeikey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MenuId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MenuId",
                table: "Articles",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AdminMenus_MenuId",
                table: "Articles",
                column: "MenuId",
                principalTable: "AdminMenus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AdminMenus_MenuId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_MenuId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Articles");
        }
    }
}
