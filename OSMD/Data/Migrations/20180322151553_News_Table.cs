using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OSMD.Data.Migrations
{
    public partial class News_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_News_Col",
                table: "News_Col");

            migrationBuilder.DropColumn(
                name: "date",
                table: "News_Col");

            migrationBuilder.RenameTable(
                name: "News_Col",
                newName: "News");

            migrationBuilder.AddColumn<string>(
                name: "_User",
                table: "News",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.DropColumn(
                name: "_User",
                table: "News");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "News_Col");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "News_Col",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_News_Col",
                table: "News_Col",
                column: "Id");
        }
    }
}
