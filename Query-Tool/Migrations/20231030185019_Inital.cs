using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Query_Tool.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    SisId = table.Column<string>(type: "TEXT", nullable: false),
                    Term = table.Column<string>(type: "TEXT", nullable: false),
                    ClassNo = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Catalog = table.Column<string>(type: "TEXT", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: false),
                    Campus = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false),
                    Enrolled = table.Column<int>(type: "INTEGER", nullable: false),
                    Cap = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CanvasCode = table.Column<int>(type: "INTEGER", nullable: true),
                    CanvasName = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.SisId);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyNo = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CanvasCode = table.Column<int>(type: "INTEGER", nullable: true),
                    CanvasName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyNo);
                });

            migrationBuilder.CreateTable(
                name: "FacultyAssignment",
                columns: table => new
                {
                    SisId = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyNo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyAssignment", x => new { x.SisId, x.FacultyNo });
                    table.ForeignKey(
                        name: "FK_FacultyAssignment_Courses_SisId",
                        column: x => x.SisId,
                        principalTable: "Courses",
                        principalColumn: "SisId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "FacultyAssignment");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
