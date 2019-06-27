using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class addIsCorrtectToTasksEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "VideoTaskStatistic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "TextTaskStatistics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "QuizTaskStatistics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "QuestionTaskStatistics",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "VideoTaskStatistic");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "TextTaskStatistics");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "QuizTaskStatistics");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "QuestionTaskStatistics");
        }
    }
}
