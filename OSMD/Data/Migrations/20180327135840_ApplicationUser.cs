using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OSMD.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "date",
            //    table: "News_Table",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Apartment",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "date",
            //    table: "News_Table");

            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");
        }
    }
}
