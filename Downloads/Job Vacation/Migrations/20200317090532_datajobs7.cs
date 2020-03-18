using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Vacation.Migrations
{
    public partial class datajobs7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrators", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    logo = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    usernamecompany = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    requirement = table.Column<string>(nullable: true),
                    informations = table.Column<string>(nullable: true),
                    flyer = table.Column<string>(nullable: true),
                    stardate = table.Column<DateTime>(nullable: false),
                    enddate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "seekers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    birthdate = table.Column<DateTime>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    cv = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seekers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "takejobs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idjob = table.Column<Guid>(nullable: false),
                    idseeker = table.Column<Guid>(nullable: false),
                    apply = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_takejobs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "seekers");

            migrationBuilder.DropTable(
                name: "takejobs");
        }
    }
}
