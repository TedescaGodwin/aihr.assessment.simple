using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aihr.assessment.api.Migrations
{
    public partial class aihr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Hours", "Name" },
                values: new object[,]
                {
                    { 1, 8.0, "Blockchain and HR" },
                    { 2, 32.0, "Compensation and Benefits" },
                    { 3, 40.0, "Digital HR" },
                    { 4, 10.0, "Digital HR Strategy" },
                    { 5, 8.0, "Digital HR Transformation " },
                    { 6, 20.0, "Diversity and Inclusion" },
                    { 7, 12.0, "Employee Experience and Design Thinking" },
                    { 8, 6.0, "Employer Branding" },
                    { 9, 12.0, "Global Data Integrity" },
                    { 10, 21.0, "HR Analytics Leader" },
                    { 11, 40.0, "HR Business Partner 2.0" },
                    { 12, 18.0, "HR Data Analyst" },
                    { 13, 12.0, "HR Data Science in R" },
                    { 14, 12.0, "HR Data Visualization" },
                    { 15, 40.0, "HR Metrics and Reporting" },
                    { 16, 30.0, "Learning and Development" },
                    { 17, 30.0, "Organizational Development" },
                    { 18, 40.0, "People Analytics" },
                    { 19, 15.0, "Statistics in HR" },
                    { 20, 34.0, "Strategic HR Leadership" },
                    { 21, 17.0, "Strategic HR Metrics" },
                    { 22, 40.0, "Talent Acquisition" },
                    { 24, 15.0, "Hiring and Recruitment Strategy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
