using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class descriptionForTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "VideoTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TextTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "QuizTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "QuestionTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "VideoTasks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TextTasks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "QuizTasks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "QuestionTasks");
        }
    }
}
