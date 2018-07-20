using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OSMD.Data.Migrations
{
    public partial class News_S : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto_News1",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News10",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News2",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News3",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News4",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News5",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News6",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News7",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News8",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Foto_News9",
                table: "News_Table");

            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link10",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link3",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link4",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link5",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link6",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link7",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link8",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link9",
                table: "News_Table",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link1",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link10",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link3",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link4",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link5",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link6",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link7",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link8",
                table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Link9",
                table: "News_Table");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News1",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News10",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News2",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News3",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News4",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News5",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News6",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News7",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News8",
                table: "News_Table",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto_News9",
                table: "News_Table",
                nullable: true);
        }
    }
}
