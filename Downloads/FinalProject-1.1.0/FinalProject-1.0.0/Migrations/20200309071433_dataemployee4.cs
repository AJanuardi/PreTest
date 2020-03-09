using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_App.Migrations
{
    public partial class dataemployee4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    cv = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    bhirtdate = table.Column<DateTime>(nullable: false),
                    bhirtplace = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    clockin = table.Column<DateTime>(nullable: false),
                    clockout = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "broadcasts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_broadcasts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    bhirtdate = table.Column<DateTime>(nullable: false),
                    bhirtplace = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    nameugd1 = table.Column<string>(nullable: true),
                    emergency1 = table.Column<string>(nullable: true),
                    nameugd2 = table.Column<string>(nullable: true),
                    emergency2 = table.Column<string>(nullable: true),
                    nameugd3 = table.Column<string>(nullable: true),
                    emergency3 = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    contract = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "leaves",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    outtime = table.Column<DateTime>(nullable: false),
                    intime = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaves", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pagings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowItem = table.Column<int>(nullable: false),
                    StatusPage = table.Column<string>(nullable: true),
                    CurrentPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "attendances");

            migrationBuilder.DropTable(
                name: "broadcasts");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "leaves");

            migrationBuilder.DropTable(
                name: "pagings");
        }
    }
}
