using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class CoursesToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursesToUsers",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesToUsers", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CoursesToUsers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesToUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesToUsers_CourseId",
                table: "CoursesToUsers",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesToUsers");
        }
    }
}
