using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class RenameCreatorToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CreatorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Courses",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                newName: "IX_Courses_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AuthorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Courses",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                newName: "IX_Courses_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CreatorId",
                table: "Courses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
