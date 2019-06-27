using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCourseSystem.DAL.Migrations
{
    public partial class addModelsForStatistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalVideoUrl",
                table: "VideoTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalImageUrl",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseStatistics_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTaskStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    UserAnswer = table.Column<string>(nullable: true),
                    CourseStatisticId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTaskStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionTaskStatistics_CourseStatistics_CourseStatisticId",
                        column: x => x.CourseStatisticId,
                        principalTable: "CourseStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizTaskStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    UserVariant = table.Column<string>(nullable: true),
                    CourseStatisticId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTaskStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizTaskStatistics_CourseStatistics_CourseStatisticId",
                        column: x => x.CourseStatisticId,
                        principalTable: "CourseStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextTaskStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    CourseStatisticId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTaskStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextTaskStatistics_CourseStatistics_CourseStatisticId",
                        column: x => x.CourseStatisticId,
                        principalTable: "CourseStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoTaskStatistic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    CourseStatisticId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTaskStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoTaskStatistic_CourseStatistics_CourseStatisticId",
                        column: x => x.CourseStatisticId,
                        principalTable: "CourseStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStatistics_ApplicationUserId",
                table: "CourseStatistics",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTaskStatistics_CourseStatisticId",
                table: "QuestionTaskStatistics",
                column: "CourseStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTaskStatistics_CourseStatisticId",
                table: "QuizTaskStatistics",
                column: "CourseStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_TextTaskStatistics_CourseStatisticId",
                table: "TextTaskStatistics",
                column: "CourseStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTaskStatistic_CourseStatisticId",
                table: "VideoTaskStatistic",
                column: "CourseStatisticId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionTaskStatistics");

            migrationBuilder.DropTable(
                name: "QuizTaskStatistics");

            migrationBuilder.DropTable(
                name: "TextTaskStatistics");

            migrationBuilder.DropTable(
                name: "VideoTaskStatistic");

            migrationBuilder.DropTable(
                name: "CourseStatistics");

            migrationBuilder.DropColumn(
                name: "LocalVideoUrl",
                table: "VideoTasks");

            migrationBuilder.DropColumn(
                name: "LocalImageUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
