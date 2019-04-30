using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class changeStructureOfCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTasks_Topics_TopicId",
                table: "QuestionTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizTasks_Topics_TopicId",
                table: "QuizTasks");

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
                name: "IX_QuizTasks_TopicId",
                table: "QuizTasks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTasks_TopicId",
                table: "QuestionTasks");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "VideoTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "QuizTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "QuestionTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextTask_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoTasks_CourseId",
                table: "VideoTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CourseId",
                table: "Topics",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTasks_CourseId",
                table: "QuizTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTasks_CourseId",
                table: "QuestionTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TextTask_CourseId",
                table: "TextTask",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTasks_Courses_CourseId",
                table: "QuestionTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizTasks_Courses_CourseId",
                table: "QuizTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTasks_Courses_CourseId",
                table: "VideoTasks");

            migrationBuilder.DropTable(
                name: "TextTask");

            migrationBuilder.DropIndex(
                name: "IX_VideoTasks_CourseId",
                table: "VideoTasks");

            migrationBuilder.DropIndex(
                name: "IX_Topics_CourseId",
                table: "Topics");

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
                name: "Description",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "QuizTasks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "QuestionTasks");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VideoTasks_TopicId",
                table: "VideoTasks",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SectionId",
                table: "Topics",
                column: "SectionId");

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
    }
}
