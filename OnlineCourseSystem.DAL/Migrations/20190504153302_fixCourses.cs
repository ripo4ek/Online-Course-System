using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class fixCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextTask_Courses_CourseId",
                table: "TextTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextTask",
                table: "TextTask");

            migrationBuilder.RenameTable(
                name: "TextTask",
                newName: "TextTasks");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "TextTasks",
                newName: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_TextTask_CourseId",
                table: "TextTasks",
                newName: "IX_TextTasks_CourseId");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "VideoTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "QuizTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "QuestionTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "QuestionTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "QuestionTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TextTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextTasks",
                table: "TextTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextTasks_Courses_CourseId",
                table: "TextTasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextTasks_Courses_CourseId",
                table: "TextTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextTasks",
                table: "TextTasks");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "VideoTasks");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "QuizTasks");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "QuestionTasks");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "QuestionTasks");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "QuestionTasks");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "TextTasks");

            migrationBuilder.RenameTable(
                name: "TextTasks",
                newName: "TextTask");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "TextTask",
                newName: "VideoUrl");

            migrationBuilder.RenameIndex(
                name: "IX_TextTasks_CourseId",
                table: "TextTask",
                newName: "IX_TextTask_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextTask",
                table: "TextTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextTask_Courses_CourseId",
                table: "TextTask",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
