using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class CourseEntityWasUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequirementKnowledge",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetAuditory",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequirementKnowledge",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TargetAuditory",
                table: "Courses");
        }
    }
}
