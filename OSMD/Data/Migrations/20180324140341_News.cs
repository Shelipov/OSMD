using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OSMD.Data.Migrations
{
    public partial class News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "News_Table");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News_Table",
                table: "News_Table",
                column: "Id");
            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "News_Table",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_News_Table",
                table: "News_Table");

            migrationBuilder.RenameTable(
                name: "News_Table",
                newName: "News");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "Id");
            migrationBuilder.DropColumn(
                name: "date",
                table: "News_Table");
        }
    }
}
