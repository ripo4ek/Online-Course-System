using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class localimageurladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaaseTime",
                table: "Post",
                newName: "ReleaseTime");

            migrationBuilder.AddColumn<string>(
                name: "ImageLocalUrl",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLocalUrl",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocalUrl",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ImageLocalUrl",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "ReleaseTime",
                table: "Post",
                newName: "ReleaaseTime");
        }
    }
}
