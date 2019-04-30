using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frame.EntityFrameworkCore.Migrations
{
    public partial class EditUserInfoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "DelTime",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "DelUser",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "UserInfos");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "UserInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "CreateUser",
                table: "UserInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelTime",
                table: "UserInfos",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DelUser",
                table: "UserInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "UserInfos",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UpdateUser",
                table: "UserInfos",
                nullable: true);
        }
    }
}
