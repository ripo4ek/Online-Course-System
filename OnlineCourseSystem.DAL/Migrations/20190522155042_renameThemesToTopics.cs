using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class renameThemesToTopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTasks_Courses_CourseId",
                table: "QuestionTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizTasks_Courses_CourseId",
                table: "QuizTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TextTasks_Courses_CourseId",
                table: "TextTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTasks_Courses_CourseId",
                table: "VideoTasks");

            migrationBuilder.DropIndex(
                name: "IX_VideoTasks_CourseId",
                table: "VideoTasks");

            migrationBuilder.DropIndex(
                name: "IX_Topics_CourseId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_TextTasks_CourseId",
                table: "TextTasks");

            migrationBuilder.DropIndex(
                name: "IX_QuizTasks_CourseId",
                table: "QuizTasks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTasks_CourseId",
                table: "QuestionTasks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "VideoTasks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "TextTasks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "QuizTasks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "QuestionTasks");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTasks_TopicId",
                table: "VideoTasks",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SectionId",
                table: "Topics",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TextTasks_TopicId",
                table: "TextTasks",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTasks_TopicId",
                table: "QuizTasks",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTasks_TopicId",
                table: "QuestionTasks",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTasks_Topics_TopicId",
                table: "QuestionTasks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizTasks_Topics_TopicId",
                table: "QuizTasks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextTasks_Topics_TopicId",
                table: "TextTasks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Sections_SectionId",
                table: "Topics",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTasks_Topics_TopicId",
                table: "VideoTasks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTasks_Topics_TopicId",
                table: "QuestionTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizTasks_Topics_TopicId",
                table: "QuizTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TextTasks_Topics_TopicId",
                table: "TextTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Sections_SectionId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTasks_Topics_TopicId",
                table: "VideoTasks");

            migrationBuilder.DropIndex(
                name: "IX_VideoTasks_TopicId",
                table: "VideoTasks");

            migrationBuilder.DropIndex(
                name: "IX_Topics_SectionId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_TextTasks_TopicId",
                table: "TextTasks");

            migrationBuilder.DropIndex(
                name: "IX_QuizTasks_TopicId",
                table: "QuizTasks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTasks_TopicId",
                table: "QuestionTasks");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "VideoTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "TextTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "QuizTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "QuestionTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoTasks_CourseId",
                table: "VideoTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CourseId",
                table: "Topics",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TextTasks_CourseId",
                table: "TextTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTasks_CourseId",
                table: "QuizTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTasks_CourseId",
                table: "QuestionTasks",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTasks_Courses_CourseId",
                table: "QuestionTasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizTasks_Courses_CourseId",
                table: "QuizTasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TextTasks_Courses_CourseId",
                table: "TextTasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTasks_Courses_CourseId",
                table: "VideoTasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
