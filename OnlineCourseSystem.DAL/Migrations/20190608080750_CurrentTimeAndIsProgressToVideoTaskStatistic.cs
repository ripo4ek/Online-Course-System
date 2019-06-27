using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class CurrentTimeAndIsProgressToVideoTaskStatistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTime",
                table: "VideoTasks");

            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "VideoTasks");

            migrationBuilder.AddColumn<double>(
                name: "CurrentTime",
                table: "VideoTaskStatistic",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "InProgress",
                table: "VideoTaskStatistic",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTime",
                table: "VideoTaskStatistic");

            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "VideoTaskStatistic");

            migrationBuilder.AddColumn<double>(
                name: "CurrentTime",
                table: "VideoTasks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "InProgress",
                table: "VideoTasks",
                nullable: false,
                defaultValue: false);
        }
    }
}
