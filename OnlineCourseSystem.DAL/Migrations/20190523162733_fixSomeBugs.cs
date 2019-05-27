using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class fixSomeBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Directions_DirectionId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Universities_UniversityId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Requierments_Courses_CourseId",
                table: "Requierments");

            migrationBuilder.DropIndex(
                name: "IX_Requierments_CourseId",
                table: "Requierments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DirectionId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UniversityId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Requierments");

            migrationBuilder.DropColumn(
                name: "CurriculumDesctiption",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DirectionId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "Courses",
                newName: "CurriculumDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurriculumDescription",
                table: "Courses",
                newName: "Target");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Requierments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurriculumDesctiption",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectionId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requierments_CourseId",
                table: "Requierments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DirectionId",
                table: "Courses",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UniversityId",
                table: "Courses",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Directions_DirectionId",
                table: "Courses",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Universities_UniversityId",
                table: "Courses",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requierments_Courses_CourseId",
                table: "Requierments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
