using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class FixedSomaBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerId",
                table: "QuizTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationInHours",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuizVariants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    QuizTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizVariants_QuizTasks_QuizTaskId",
                        column: x => x.QuizTaskId,
                        principalTable: "QuizTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizTasks_CorrectAnswerId",
                table: "QuizTasks",
                column: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizVariants_QuizTaskId",
                table: "QuizVariants",
                column: "QuizTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizTasks_QuizVariants_CorrectAnswerId",
                table: "QuizTasks",
                column: "CorrectAnswerId",
                principalTable: "QuizVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizTasks_QuizVariants_CorrectAnswerId",
                table: "QuizTasks");

            migrationBuilder.DropTable(
                name: "QuizVariants");

            migrationBuilder.DropIndex(
                name: "IX_QuizTasks_CorrectAnswerId",
                table: "QuizTasks");

            migrationBuilder.DropColumn(
                name: "CorrectAnswerId",
                table: "QuizTasks");

            migrationBuilder.DropColumn(
                name: "DurationInHours",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
