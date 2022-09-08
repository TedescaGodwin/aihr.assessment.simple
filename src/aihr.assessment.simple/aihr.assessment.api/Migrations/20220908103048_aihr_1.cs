using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aihr.assessment.api.Migrations
{
    public partial class aihr_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");
        }
    }
}
